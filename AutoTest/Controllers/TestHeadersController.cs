using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AutoTest.Clases;
using AutoTest.Models;
using Newtonsoft.Json.Linq;

namespace AutoTest.Controllers
{
    [Authorize(Roles = "User")]
    public class TestHeadersController : Controller
    {
        private AtestContext db = new AtestContext();

        [HttpPost]
        public ActionResult editdetailtmp(int id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            //Update to database
            using (AtestContext db = new AtestContext())
            {
                var testDetailTmp = db.TestDetailTmps.Find(id);

                object updateValue = value;
                bool isValid = true;

                if (propertyName == "TestAnswerID")
                {
                    int newTestAnswerID = 0;
                    if (int.TryParse(value, out newTestAnswerID))
                    {
                        updateValue = newTestAnswerID;
                        //update value field
                        value = db.TestAnswers.Where(a => a.TestAnswerID == newTestAnswerID).First().Value;
                    }
                    else
                    {
                        isValid = false;
                    }
                }

                if (testDetailTmp != null && isValid)
                {
                    db.Entry(testDetailTmp).Entity.TestAnswerID = int.Parse(updateValue.ToString());
                    db.SaveChanges();
                    status = true;
                }
                else
                {
                    message = "Error!";
                }
            }

            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);
            return Content(o.ToString());
        }


        public ActionResult GetTestAnswerValor(int id)
        {
            //{'E':'Letter E','F':'Letter F','G':'Letter G', 'selected':'F'}
            int selectedValueID = 0;
            StringBuilder sb = new StringBuilder();
            using (AtestContext db = new AtestContext())
            {
                var listValue = db.TestAnswers.OrderBy(a => a.Value).ToList();
                foreach (var item in listValue)
                {
                    sb.Append(string.Format("'{0}':'{1}',", item.TestAnswerID, item.Value));
                }

                selectedValueID = db.TestDetailTmps.Where(a => a.TestDetailTmpID == id).First().TestAnswerID;
            }
            sb.Append(string.Format("'selected': '{0}'", selectedValueID));
            return Content("{" + sb.ToString() + "}");
        }

        public ActionResult SummaryImportance()
        {
            //crea las variables con el ID que necesitamos para insertarlo en TestDetailTmp
            List<SubCategory>SubCategories = new List<SubCategory>();

            SubCategories = db.SubCategories.ToList<SubCategory>();
            var testDetailTmps = new List<TestDetailTmp>();

            foreach (var item in SubCategories)
            {
                new TestDetailTmp();
                testDetailTmps.Add(new TestDetailTmp() { SubCategoryID = item.SubCategoryID, SubCategoryName = item.SubCategoryName, UserName = User.Identity.Name, TestAnswerID = 1 });
            }

            //crea la variable de tipo lista para ingresar los datos en la tabla TestDetailTmp


            //Agrega los datos con sus parametros a la tabla TestDetailTmp
            int CantSubCategoriesXUser = db.TestDetailTmps.Count( x => x.UserName == User.Identity.Name);

                if (CantSubCategoriesXUser == 0)
                {
                db.TestDetailTmps.AddRange(testDetailTmps);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

                
               else
               {
                TempData["msg"] = "You have already selected this record, try another one ..";
                return RedirectToAction("Create");
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
            ViewBag.Msg = TempData["msg"];

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
