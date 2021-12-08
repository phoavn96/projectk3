using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Survey.Models;

namespace Survey.Controllers
{
    public class QuestionAnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuestionAnswers
        public ActionResult Index()
        {

            var question_answers = db.Question_answers.Include(q => q.Question);
            return View(question_answers.ToList());
        }

        // GET: QuestionAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.Question_answers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswer);
        }

        // GET: QuestionAnswers/Create
        [Authorize(Roles = "Admin")]
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BigModel bigModels)
        {


            // Loop and insert records.


            foreach (var allSurvey in bigModels.AllSurvey)
            {
                allSurvey.Status = SurveyStatus.NOT_HAPPENNING_YET;
                allSurvey.CreateDate = DateTime.Now;
                allSurvey.UpdateDate = DateTime.Now.AddDays(7);
                db.Surveys.Add(allSurvey);
                db.SaveChanges();
                int newIdSurvey = db.Surveys.Max(s => s.SurveyId);
                int newIdQuest = 0;
                string titleTemp;
                int sttQuest = 0;
                for (int i = 0; i < bigModels.Question.Count; i++)
                {
                    bigModels.Question[i].SurveyId = newIdSurvey;
                    db.Questions.Add(bigModels.Question[i]);
                    db.SaveChanges();
                    if(i == 0)
                    {
                        newIdQuest = db.Questions.Max(q => q.Id);
                    }
                    if (bigModels.Question[i].Type == 3)
                    {
                        QaTemp q = new QaTemp();
                        q.Answer = "Other";
                        q.Title = bigModels.Question[i].Title;
                        bigModels.QaTemps.Add(q);
                    }
                    if (bigModels.Question[i].Type == 4)
                    {
                        QaTemp q = new QaTemp();
                        q.Answer = "Essay";
                        q.Title = bigModels.Question[i].Title;
                        bigModels.QaTemps.Add(q);
                    }
                    if (i == bigModels.Question.Count - 1)
                    {
                        titleTemp = bigModels.Question[sttQuest].Title;
                        foreach (var qaTemp in bigModels.QaTemps)
                        {
                            QuestionAnswer questionAnswer = new QuestionAnswer();
                            if (!qaTemp.Title.Equals(titleTemp))
                            {
                                titleTemp = qaTemp.Title;
                                newIdQuest++;
                                sttQuest++;
                            }
                            questionAnswer.Answer = qaTemp.Answer;
                            questionAnswer.QuestionId = newIdQuest;
                            questionAnswer.Answer = qaTemp.Answer;
                            db.Question_answers.Add(questionAnswer);
                            //bigModels.QaTemps.Remove(qaTemp);
                        }
                    }

                }

            }
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        // GET: QuestionAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.Question_answers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", questionAnswer.QuestionId);
            return View(questionAnswer);
        }

        // POST: QuestionAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionAnswerId,Answer,QuestionId")] QuestionAnswer questionAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", questionAnswer.QuestionId);
            return View(questionAnswer);
        }

        // GET: QuestionAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = db.Question_answers.Find(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswer);
        }

        // POST: QuestionAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionAnswer questionAnswer = db.Question_answers.Find(id);
            db.Question_answers.Remove(questionAnswer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
