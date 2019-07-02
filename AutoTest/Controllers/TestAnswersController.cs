using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoTest.Models;

namespace AutoTest.Controllers
{
    public class TestAnswersController : Controller
    {
        private AtestContext db = new AtestContext();

        // GET: TestAnswers
        public ActionResult Index()
        {
            return View(db.TestAnswers.ToList());
        }

        // GET: TestAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestAnswer testAnswer = db.TestAnswers.Find(id);
            if (testAnswer == null)
            {
                return HttpNotFound();
            }
            return View(testAnswer);
        }

        // GET: TestAnswers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestAnswer testAnswer)
        {
            if (ModelState.IsValid)
            {
                db.TestAnswers.Add(testAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testAnswer);
        }

        // GET: TestAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestAnswer testAnswer = db.TestAnswers.Find(id);
            if (testAnswer == null)
            {
                return HttpNotFound();
            }
            return View(testAnswer);
        }

        // POST: TestAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestAnswer testAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testAnswer);
        }

        // GET: TestAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestAnswer testAnswer = db.TestAnswers.Find(id);
            if (testAnswer == null)
            {
                return HttpNotFound();
            }
            return View(testAnswer);
        }

        // POST: TestAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestAnswer testAnswer = db.TestAnswers.Find(id);
            db.TestAnswers.Remove(testAnswer);
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
