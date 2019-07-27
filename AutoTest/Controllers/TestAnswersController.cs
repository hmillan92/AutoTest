using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoTest.Models;
using PagedList;

namespace AutoTest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestAnswersController : Controller
    {
        private AtestContext db = new AtestContext();

        // GET: TestAnswers
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var testAnswer = db.TestAnswers.ToList().OrderBy(ta => ta.Value);
            return View(testAnswer.ToPagedList((int)page, 4));
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

                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "this record already exists");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }

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

                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "this record already exists");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
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
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, "Not allowed, there are records in the temporary tables of users with this value, please wait until there are no records there using this value and try again or contact the administrator");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(testAnswer);
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
