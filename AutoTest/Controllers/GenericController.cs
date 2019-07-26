using AutoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoTest.Controllers
{
    public class GenericController : Controller
    {
        private AtestContext db = new AtestContext();

        public JsonResult GetSubCategories(int businessEntityID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var subCategories = db.SubCategories.Where(b => b.BusinessEntityID == businessEntityID);
            return Json(subCategories);
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