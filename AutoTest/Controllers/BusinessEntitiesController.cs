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
    [Authorize(Roles = "Admin")]
    public class BusinessEntitiesController : Controller
    {
        private AtestContext db = new AtestContext();

        // GET: BusinessEntities
        public ActionResult Index()
        {
            return View(db.BusinessEntities.ToList());
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
                db.SaveChanges();
                return RedirectToAction("Index");
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
                    ModelState.AddModelError(string.Empty, "It can not be deleted because it contains many records, please delete the records that are associated with this category and try again");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

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
