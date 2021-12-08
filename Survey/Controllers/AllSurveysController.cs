using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Survey.Models;
using Microsoft.AspNet.Identity;
namespace Survey.Controllers
{
    public class AllSurveysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AllSurveys
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            return View(db.Surveys.ToList());

        }

        // GET: AllSurveys/Details/5
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
        [Authorize(Roles = "Admin")]
        // GET: AllSurveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllSurveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurveyId,Title,CreateDate,UpdateDate,Description,Status")] AllSurvey allSurvey)
        {
            if (ModelState.IsValid)
            {
                allSurvey.Status = SurveyStatus.NOT_HAPPENNING_YET;
                allSurvey.CreateDate = DateTime.Now;
                allSurvey.UpdateDate = DateTime.Now;
                db.Surveys.Add(allSurvey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allSurvey);
        }

        // GET: AllSurveys/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: AllSurveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurveyId,Title,CreateDate,UpdateDate,Description,Status")] AllSurvey allSurvey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allSurvey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allSurvey);
        }

        // GET: AllSurveys/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: AllSurveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllSurvey allSurvey = db.Surveys.Find(id);
            db.Surveys.Remove(allSurvey);
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
        public ActionResult HelloAjax(string q)
        {
            return View("Index", this.db.Surveys.Where(item => item.Title.Contains(q)).ToList());
        }
    }
}
