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


        public ActionResult ListSummaryDetailTmp()
        {
            //crea la lista para insertarlo en TestDetailTmp
            List<SubCategory> SubCategories = new List<SubCategory>();

            SubCategories = db.SubCategories.ToList<SubCategory>();
            var testSummaryDetailTmps = new List<TestSummaryDetailTmp>();

            foreach (var item in SubCategories)
            {
                new TestSummaryDetailTmp();
                testSummaryDetailTmps.Add(new TestSummaryDetailTmp() { SubCategoryID = item.SubCategoryID, SubCategoryName = item.SubCategoryName, UserName = User.Identity.Name, TestAnswerID = 1 });
            }


            //Valida si hay registro 
            int CantSummaryImportanceXUser = db.TestSummaryDetailTmps.Count(x => x.UserName == User.Identity.Name);

            if (CantSummaryImportanceXUser == 0)
            {
                db.TestSummaryDetailTmps.AddRange(testSummaryDetailTmps);
                db.SaveChanges();
                return RedirectToAction("Create");
            }


            else
            {
                TempData["msg"] = "You have already selected this record, try another one ..";
                return RedirectToAction("Create");
            }

        }

        [HttpPost]
        public ActionResult EditSummaryDetailTmp(int id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            //Update to database
            using (AtestContext db = new AtestContext())
            {
                var testSummaryDetailTmp = db.TestSummaryDetailTmps.Find(id);

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

                if (testSummaryDetailTmp != null && isValid)
                {
                    db.Entry(testSummaryDetailTmp).Entity.TestAnswerID = int.Parse(updateValue.ToString());
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


        public ActionResult GetSummaryDetailTmpAnswer(int id)
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

                selectedValueID = db.TestSummaryDetailTmps.Where(a => a.TestSummaryDetailTmpID == id).First().TestAnswerID;
            }
            sb.Append(string.Format("'selected': '{0}'", selectedValueID));
            return Content("{" + sb.ToString() + "}");
        }

        


        public ActionResult ListQuestionDetailTmp()
        {
            //crea la lista para insertarlo en TestDetailTmp
            List<Question> questions = new List<Question>();

            questions = db.Questions.ToList<Question>();
            var testQuestionDetailTmps = new List<TestQuestionDetailTmp>();

            foreach (var item in questions)
            {
                new TestQuestionDetailTmp();
                testQuestionDetailTmps.Add(new TestQuestionDetailTmp() { BusinessEntityID = item.BusinessEntityID, SubCategoryID = item.SubCategoryID, QuestionID = item.QuestionID, QuestionName = item.QuestionName, UserName = User.Identity.Name, TestAnswerID = 1 });
            }


            //Valida si hay registro 
            int CantQuestionXUser = db.TestQuestionDetailTmps.Count(x => x.UserName == User.Identity.Name);

            if (CantQuestionXUser == 0)
            {
                db.TestQuestionDetailTmps.AddRange(testQuestionDetailTmps);
                db.SaveChanges();
                return RedirectToAction("Create");
            }


            else
            {
                TempData["msg"] = "You have already selected this record, try another one ..";
                return RedirectToAction("Create");
            }

        }

        [HttpPost]
        public ActionResult EditQuestionDetailTmp(int id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            //Update to database
            using (AtestContext db = new AtestContext())
            {
                var testQuestionDetailTmp = db.TestQuestionDetailTmps.Find(id);

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

                if (testQuestionDetailTmp != null && isValid)
                {
                    db.Entry(testQuestionDetailTmp).Entity.TestAnswerID = int.Parse(updateValue.ToString());
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

        public ActionResult GetQuestionDetailTmpAnswer(int id)
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

                selectedValueID = db.TestQuestionDetailTmps.Where(a => a.TestQuestionDetailTmpID == id).First().TestAnswerID;
            }
            sb.Append(string.Format("'selected': '{0}'", selectedValueID));
            return Content("{" + sb.ToString() + "}");
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
                SummaryDetails = db.TestSummaryDetailTmps.Where(tdt => tdt.UserName == User.Identity.Name).ToList(),
                QuestionDetails = db.TestQuestionDetailTmps.Where(tqdt => tqdt.UserName == User.Identity.Name).ToList(),
            };
            return View(view);
        }

        // POST: TestHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewTestView view)
        {
            if (ModelState.IsValid)
            {
                var response = MovementsHelper.NewTest(view, User.Identity.Name);
                if (response.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, response.Message);
            }

            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", view.UserID);
            view.SummaryDetails = db.TestSummaryDetailTmps.Where(tdt => tdt.UserName == User.Identity.Name).ToList();
            return View(view);
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
