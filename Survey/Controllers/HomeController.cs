using Microsoft.AspNet.Identity;
using Microsoft.JScript;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Survey.Controllers
{
    public class HomeController : Controller
    {
        public int countAllSurvey;
        public int countAllSurveyAnswered;
        public int countAllSurveyComplete;
        public DateTime localDate = DateTime.Now;
        private ApplicationDbContext db = new ApplicationDbContext();
        public AllSurvey nextSurvey = new AllSurvey(); 

        public ActionResult Index()
        {
            countAllSurvey = db.Surveys.Count();
            countAllSurveyComplete = db.Surveys.Where(c => c.Status == SurveyStatus.DONE).Count();
            AllSurvey allSurvey = db.Surveys.Where(c => c.UpdateDate > localDate).FirstOrDefault();
            if(allSurvey != null)
            {
                nextSurvey = allSurvey;
            }

            if (User.Identity.GetUserId() != null)
            {
                var uid = User.Identity.GetUserId();
                var count = db.Account_answers.Where(a => a.Id == uid).GroupBy(a => a.SurveyId).Count();
                countAllSurveyAnswered = count;
            }
            else
            {
                countAllSurveyAnswered = 0;
            }
            ViewBag.NextSurvey = nextSurvey;
            ViewBag.AllSurvey = countAllSurvey;
            ViewBag.AllSurveyAnswered = countAllSurveyAnswered;
            ViewBag.AllSurveyComplete = countAllSurveyComplete;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FAQHome()
        {

            return View(db.FAQs.ToList());
        }
        public ActionResult SupportHome()
        {

            return View(db.Supports.ToList());
        }
        [Authorize]
        public ActionResult Survey()
        {
            List<AllSurvey> surveys = db.Surveys.Where(s => s.Status.ToString() == "NOT_HAPPENNING_YET" || s.Status.ToString() == "HAPPENNING" || s.Status.ToString() == "DONE").ToList();
            var owner = new List<String>();
            var userId = User.Identity.GetUserId();
            foreach (var i in surveys)
            {
                if(db.Account_answers.Where(u => u.Id ==userId ).Where(s => s.SurveyId == i.SurveyId).Count() != 0)
                {
                    owner.Add("Submitted!");
                }
                else
                {
                    owner.Add("Not Yet Submitted");
                }
                
            }
            ViewBag.AccStatus = owner;
                

            return View(surveys);
        }

        [Authorize]
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllSurvey allSurvey = db.Surveys.Find(id);
            if (allSurvey == null)
            {
                return HttpNotFound();
            }
            return View(allSurvey);
        }
        [Authorize]
        [HttpPost]
        public ActionResult SaveAnswer()
        {
            var currentSurveyId = HttpContext.Request.Form["currentsurvey"];
            AllSurvey survey = db.Surveys.Where(i => i.SurveyId.ToString() == currentSurveyId).FirstOrDefault();
            var accountId = User.Identity.GetUserId();
            foreach (var item in survey.Questions)
            {

                if (item.Type == 0)
                {

                    var a = HttpContext.Request.Form[item.Id.ToString()];
                    int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == a).FirstOrDefault().QuestionAnswerId;
                    AccountAnswer answer = new AccountAnswer
                    {
                        SurveyId = survey.SurveyId,
                        Id = accountId,
                        QuestionAnswerId = qId,
                        Status = 1,
                        Description = HttpContext.Request.Form[item.Id.ToString()]

                    };
                    db.Account_answers.Add(answer);

                }

                if (item.Type == 1)
                {
                    string a = HttpContext.Request.Form[item.Id.ToString()];
                    int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == a).FirstOrDefault().QuestionAnswerId;
                    AccountAnswer answer = new AccountAnswer
                    {
                        SurveyId = survey.SurveyId,
                        Id = accountId,
                        QuestionAnswerId = qId,
                        Status = 1,
                        Description = HttpContext.Request.Form[item.Id.ToString()]
                    };
                    db.Account_answers.Add(answer);


                }
                if (item.Type == 2)
                {
                    List<String> listAnswer = HttpContext.Request.Form[item.Id.ToString()].Split(',').ToList();

                    foreach (var a in listAnswer)
                    {
                        int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == a).FirstOrDefault().QuestionAnswerId;
                        AccountAnswer answer = new AccountAnswer
                        {
                            SurveyId = survey.SurveyId,
                            Id = accountId,
                            QuestionAnswerId = qId,
                            Status = 1,
                            Description = a

                        };
                        db.Account_answers.Add(answer);

                    }

                }
                if (item.Type == 3)
                {

                    List<String> listAnswer = HttpContext.Request.Form[item.Id.ToString()].Split(',').ToList();
                    if (listAnswer[0] == "Other")
                    {
                        int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == "Other").FirstOrDefault().QuestionAnswerId;
                        AccountAnswer answer = new AccountAnswer
                        {

                            SurveyId = survey.SurveyId,
                            Id = accountId,
                            QuestionAnswerId = qId,
                            Status = 1,
                            Description = listAnswer[1]

                        };
                        db.Account_answers.Add(answer);
                    }
                    if (listAnswer[0] != "Other")
                    {
                        var des = listAnswer[0];
                        int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == des).FirstOrDefault().QuestionAnswerId;
                        AccountAnswer answer = new AccountAnswer
                        {
                            SurveyId = survey.SurveyId,
                            Id = accountId,
                            QuestionAnswerId = qId,
                            Status = 1,
                            Description = des
                        };
                        db.Account_answers.Add(answer);
                    }

                }
                if (item.Type == 4)
                {

                    int qId = db.Question_answers.Where(q => q.QuestionId == item.Id).ToList().Where(d => d.Answer == "Essay").FirstOrDefault().QuestionAnswerId;
                    AccountAnswer answer = new AccountAnswer
                    {
                        SurveyId = survey.SurveyId,
                        Id = accountId,
                        QuestionAnswerId = qId,
                        Status = 1,
                        Description = HttpContext.Request.Form[item.Id.ToString()]
                    };
                    db.Account_answers.Add(answer);
                }
                db.SaveChanges();

            }
            return Redirect("~/Home/Survey");
        }
        



        
     

    }
}