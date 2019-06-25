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

        public ActionResult SummaryImportance()
        {
            //crea las variables con el ID que necesitamos para insertarlo en TestDetailTmp
                var subCategory1 = db.SubCategories.Find(1);
                var subCategory2 = db.SubCategories.Find(2);
                var subCategory3 = db.SubCategories.Find(3);
                var subCategory4 = db.SubCategories.Find(4);

                var subCategory6 = db.SubCategories.Find(6);
                var subCategory7 = db.SubCategories.Find(7);
                var subCategory8 = db.SubCategories.Find(8);
                var subCategory9 = db.SubCategories.Find(9);

                var subCategory10 = db.SubCategories.Find(10);
                var subCategory11 = db.SubCategories.Find(11);
                var subCategory12 = db.SubCategories.Find(12);
                var subCategory13 = db.SubCategories.Find(13);

                var subCategory14 = db.SubCategories.Find(14);
                var subCategory15 = db.SubCategories.Find(15);
                var subCategory16 = db.SubCategories.Find(16);
                var subCategory17 = db.SubCategories.Find(17);

                var subCategory18 = db.SubCategories.Find(18);
                var subCategory19 = db.SubCategories.Find(19);
                var subCategory20 = db.SubCategories.Find(20);
                var subCategory21 = db.SubCategories.Find(21);

                var subCategory22 = db.SubCategories.Find(22);
                var subCategory23 = db.SubCategories.Find(23);
                var subCategory24 = db.SubCategories.Find(24);
                var subCategory25 = db.SubCategories.Find(25);

                //crea la variable de tipo lista para ingresar los datos en la tabla TestDetailTmp
                var testDetailTmps = new List<TestDetailTmp>();

                //Agrega los datos con sus parametros a la tabla TestDetailTmp
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory1.SubCategoryID, SubCategoryName = subCategory1.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory2.SubCategoryID, SubCategoryName = subCategory2.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory3.SubCategoryID, SubCategoryName = subCategory3.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory4.SubCategoryID, SubCategoryName = subCategory4.SubCategoryName, UserName = User.Identity.Name, Value = 0 });

                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory6.SubCategoryID, SubCategoryName = subCategory6.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory7.SubCategoryID, SubCategoryName = subCategory7.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory8.SubCategoryID, SubCategoryName = subCategory8.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory9.SubCategoryID, SubCategoryName = subCategory9.SubCategoryName, UserName = User.Identity.Name, Value = 0 });

                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory10.SubCategoryID, SubCategoryName = subCategory10.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory11.SubCategoryID, SubCategoryName = subCategory11.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory12.SubCategoryID, SubCategoryName = subCategory12.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory13.SubCategoryID, SubCategoryName = subCategory13.SubCategoryName, UserName = User.Identity.Name, Value = 0 });

                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory14.SubCategoryID, SubCategoryName = subCategory14.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory15.SubCategoryID, SubCategoryName = subCategory15.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory16.SubCategoryID, SubCategoryName = subCategory16.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory17.SubCategoryID, SubCategoryName = subCategory17.SubCategoryName, UserName = User.Identity.Name, Value = 0 });

                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory18.SubCategoryID, SubCategoryName = subCategory18.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory19.SubCategoryID, SubCategoryName = subCategory19.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory20.SubCategoryID, SubCategoryName = subCategory20.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory21.SubCategoryID, SubCategoryName = subCategory21.SubCategoryName, UserName = User.Identity.Name, Value = 0 });

                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory22.SubCategoryID, SubCategoryName = subCategory22.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory23.SubCategoryID, SubCategoryName = subCategory23.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory24.SubCategoryID, SubCategoryName = subCategory24.SubCategoryName, UserName = User.Identity.Name, Value = 0 });
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = subCategory25.SubCategoryID, SubCategoryName = subCategory25.SubCategoryName, UserName = User.Identity.Name, Value = 0 });

                db.TestDetailTmps.AddRange(testDetailTmps);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }

                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "Not allowed, you already have this list");
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return RedirectToAction("Create");
                    }

                }
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
