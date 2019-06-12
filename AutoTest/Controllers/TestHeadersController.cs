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

namespace AutoTest.Controllers
{
    [Authorize(Roles = "User")]
    public class TestHeadersController : Controller
    {
        private AtestContext db = new AtestContext();

        public ActionResult AddSubCategory()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.BusinessEntityID = new SelectList(CombosHelper.GetBusinessEntities(), "BusinessEntityID", "BusinessEntityName");
            return View();
        }

        [HttpPost]
        public ActionResult AddSubCategory(AddSubCategoryView view)
        {
            //Si el modelo es valido
            if (ModelState.IsValid)
            {
                //Busca el ID en la tabla subCategory lo que tenemos en el AddSubcategoryView
                var subCategory = db.SubCategories.Find(view.BusinessEntityID);
                //Crea el TestDetailTmp
                var testDetailTmp = new TestDetailTmp
                {
                    BusinessEntityID = subCategory.BusinessEntityID,

                    SubCategoryName = subCategory.SubCategoryName,
                    Value = view.Value,
                    UserName = User.Identity.Name,
                };
                //Ahora lo mandamos a la abase de datos
                db.TestDetailTmps.Add(testDetailTmp);
                db.SaveChanges();
                //Y mandamos al usuario a la vista create

            }
            //Si el modelo no es valido lo volvemos a pintar 
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.BusinessEntityID = new SelectList(CombosHelper.GetBusinessEntities(), "BusinessEntityID", "BusinessEntityName");

            return View(view);
        }

            // GET: TestHeaders
            public ActionResult Index()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var testHeaders = db.TestHeaders.Where(t => t.UserID == user.UserID).Include(t => t.State).Include(t => t.User);
            return View(testHeaders.ToList());

            //var testHeaders = db.TestHeaders.Include(t => t.State).Include(t => t.User);
            //return View(testHeaders.ToList());
        }

        // GET: TestHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var testHeader = db.TestHeaders.Find(id);
            if (testHeader == null)
            {
                return HttpNotFound();
            }
            return View(testHeader);
        }

        // GET: TestHeaders/Create
        public ActionResult Create()
        {
            //para buscar el usuario logeado
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var view = new NewTestView
            {
                Date = DateTime.Now,
                Details = db.TestDetailTmps.Where(tdt => tdt.UserName == User.Identity.Name).ToList(),
            };
            return View(view);
        }

        // POST: TestHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestHeader testHeader)
        {
            if (ModelState.IsValid)
            {
                db.TestHeaders.Add(testHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", testHeader.UserID);
            return View(testHeader);
        }

        // GET: TestHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestHeader testHeader = db.TestHeaders.Find(id);
            if (testHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", testHeader.StateID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", testHeader.UserID);
            return View(testHeader);
        }

        // POST: TestHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestHeaderID,Date,UserID,StateID")] TestHeader testHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", testHeader.StateID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", testHeader.UserID);
            return View(testHeader);
        }

        // GET: TestHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestHeader testHeader = db.TestHeaders.Find(id);
            if (testHeader == null)
            {
                return HttpNotFound();
            }
            return View(testHeader);
        }

        // POST: TestHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestHeader testHeader = db.TestHeaders.Find(id);
            db.TestHeaders.Remove(testHeader);
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
