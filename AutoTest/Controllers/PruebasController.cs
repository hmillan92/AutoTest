using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AutoTest.Models;
using Newtonsoft.Json.Linq;

namespace AutoTest.Controllers
{
    [Authorize(Roles = "User")]
    public class PruebasController : Controller
    {
        private AtestContext db = new AtestContext();

        // GET: Pruebas
        public ActionResult Index()
        {
            var pruebas = db.Pruebas.Include(p => p.Lista);
            return View(pruebas.ToList());
        }

        [HttpPost]
        public ActionResult saveuser(int id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            //Update to database
            using (AtestContext db = new AtestContext())
            {
                var pruebas = db.Pruebas.Find(id);

                object updateValue = value;
                bool isValid = true;

                if (propertyName == "ListaId")
                {
                    int newListaID = 0;
                    if (int.TryParse(value, out newListaID))
                    {
                        updateValue = newListaID;
                        //update value field
                        value = db.Listas.Where(a => a.ListaID == newListaID).First().Valor;
                    }
                    else
                    {
                        isValid = false;
                    }
                }

                if (pruebas != null && isValid)
                {
                    db.Entry(pruebas).Entity.ListaID = int.Parse(updateValue.ToString());
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

        public ActionResult GetListaValor(int id)
        {
            //{'E':'Letter E','F':'Letter F','G':'Letter G', 'selected':'F'}
            int selectedValorID = 0;
            StringBuilder sb = new StringBuilder();
            using (AtestContext db = new AtestContext())
            {
                var listaValor = db.Listas.OrderBy(a => a.Valor).ToList();
                foreach (var item in listaValor)
                {
                    sb.Append(string.Format("'{0}':'{1}',", item.ListaID, item.Valor));
                }

                selectedValorID = db.Pruebas.Where(a => a.PruebaID == id).First().ListaID;
            }
            sb.Append(string.Format("'selected': '{0}'", selectedValorID));
            return Content("{" + sb.ToString() + "}");
        }

        // GET: Pruebas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Pruebas.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // GET: Pruebas/Create
        public ActionResult Create()
        {
            ViewBag.ListaID = new SelectList(db.Listas, "ListaID", "Valor");
            return View();
        }

        // POST: Pruebas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                db.Pruebas.Add(prueba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListaID = new SelectList(db.Listas, "ListaID", "Valor", prueba.ListaID);
            return View(prueba);
        }

        //// GET: Pruebas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Prueba prueba = db.Pruebas.Find(id);
        //    if (prueba == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ListaID = new SelectList(db.Listas, "ListaID", "Name", prueba.ListaID);
        //    return View(prueba);
        //}

        //// POST: Pruebas/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PruebaID,Name,ListaID")] Prueba prueba)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(prueba).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ListaID = new SelectList(db.Listas, "ListaID", "Name", prueba.ListaID);
        //    return View(prueba);
        //}

        // GET: Pruebas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prueba prueba = db.Pruebas.Find(id);
            if (prueba == null)
            {
                return HttpNotFound();
            }
            return View(prueba);
        }

        // POST: Pruebas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prueba prueba = db.Pruebas.Find(id);
            db.Pruebas.Remove(prueba);
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