﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoTest.Clases;
using AutoTest.Models;

namespace AutoTest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubCategoriesController : Controller
    {
        private AtestContext db = new AtestContext();

        // GET: SubCategories
        public ActionResult Index()
        {
            var subCategories = db.SubCategories.Include(s => s.BusinessEntity);
            return View(subCategories.ToList());
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: SubCategories/Create
        public ActionResult Create()
        {
            
            ViewBag.BusinessEntityID = new SelectList(
                CombosHelper.GetBusinessEntities(), //trae del helper la lista ordenada del combo
                "BusinessEntityID", //lo que llama
                "BusinessEntityName");// lo que muestra
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.SubCategories.Add(subCategory);
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

            ViewBag.BusinessEntityID = new SelectList(
                CombosHelper.GetBusinessEntities(), //trae del helper la lista ordenada del combo, 
                "BusinessEntityID", 
                "BusinessEntityName", 
                subCategory.BusinessEntityID);
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessEntityID = new SelectList(
                CombosHelper.GetBusinessEntities(), //trae del helper la lista ordenada del combo,
                "BusinessEntityID", 
                "BusinessEntityName", 
                subCategory.BusinessEntityID);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessEntityID = new SelectList(
                CombosHelper.GetBusinessEntities(), //trae del helper la lista ordenada del combo, 
                "BusinessEntityID", 
                "BusinessEntityName", 
                subCategory.BusinessEntityID);
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory subCategory = db.SubCategories.Find(id);
            db.SubCategories.Remove(subCategory);
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

            return View(subCategory);
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
