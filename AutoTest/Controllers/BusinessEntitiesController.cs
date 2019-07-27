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
    public class BusinessEntitiesController : Controller
    {
        private AtestContext db = new AtestContext();

        // GET: BusinessEntities
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var businessEntity = db.BusinessEntities.OrderBy(be => be.BusinessEntityName);
            return View(businessEntity.ToPagedList((int)page, 4));
        }

        // GET: BusinessEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessEntity businessEntity = db.BusinessEntities.Find(id);
            if (businessEntity == null)
            {
                return HttpNotFound();
            }
            return View(businessEntity);
        }

        // GET: BusinessEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BusinessEntity businessEntity)
        {
            if (ModelState.IsValid)
            {
                db.BusinessEntities.Add(businessEntity);
                var response = DBHelper.SaveChanges(db);
                if (response.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, response.Message);            
            }

            return View(businessEntity);
        }

        // GET: BusinessEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessEntity businessEntity = db.BusinessEntities.Find(id);
            if (businessEntity == null)
            {
                return HttpNotFound();
            }
            return View(businessEntity);
        }

        // POST: BusinessEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessEntity businessEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessEntity).State = EntityState.Modified;
                var response = DBHelper.SaveChanges(db);
                if (response.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            return View(businessEntity);
        }

        // GET: BusinessEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessEntity businessEntity = db.BusinessEntities.Find(id);
            if (businessEntity == null)
            {
                return HttpNotFound();
            }
            return View(businessEntity);
        }

        // POST: BusinessEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessEntity businessEntity = db.BusinessEntities.Find(id);
            db.BusinessEntities.Remove(businessEntity);
            var response = DBHelper.SaveChanges(db);
            if (response.Succeeded)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, response.Message);
            return View(businessEntity);
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
