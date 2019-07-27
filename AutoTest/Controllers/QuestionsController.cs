using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoTest.Clases;
using AutoTest.Models;
using PagedList;

namespace AutoTest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestionsController : Controller
    {
        private AtestContext db = new AtestContext();

        // GET: Questions
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var questions = db.Questions.Include(q => q.BusinessEntity).Include(q => q.SubCategory).OrderBy(q => q.BusinessEntity.BusinessEntityName).ThenBy(q => q.SubCategory.SubCategoryName);
            return View(questions.ToPagedList((int)page,5));
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.BusinessEntityID = new SelectList(CombosHelper.GetBusinessEntities(), "BusinessEntityID", "BusinessEntityName");
            ViewBag.SubCategoryID = new SelectList(CombosHelper.GetSubCategories(0), "SubCategoryID", "SubCategoryName");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessEntityID = new SelectList(CombosHelper.GetBusinessEntities(), "BusinessEntityID", "BusinessEntityName", question.BusinessEntityID);
            ViewBag.SubCategoryID = new SelectList(CombosHelper.GetSubCategories(question.BusinessEntityID), "SubCategoryID", "SubCategoryName", question.SubCategoryID);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessEntityID = new SelectList(CombosHelper.GetBusinessEntities(), "BusinessEntityID", "BusinessEntityName", question.BusinessEntityID);
            ViewBag.SubCategoryID = new SelectList(CombosHelper.GetSubCategories(question.BusinessEntityID), "SubCategoryID", "SubCategoryName", question.SubCategoryID);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessEntityID = new SelectList(CombosHelper.GetBusinessEntities(), "BusinessEntityID", "BusinessEntityName", question.BusinessEntityID);
            ViewBag.SubCategoryID = new SelectList(CombosHelper.GetSubCategories(question.BusinessEntityID), "SubCategoryID", "SubCategoryName", question.SubCategoryID);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
