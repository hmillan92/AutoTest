using AutoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoTest.Clases
{
    public class CombosHelper : IDisposable
    {
        static AtestContext db = new AtestContext();

        public static List<BusinessEntity> GetBusinessEntities()
        {
            var businessEntity = db.BusinessEntities.ToList();
            businessEntity.Add(new BusinessEntity
            {
                BusinessEntityID = 0,
                BusinessEntityName = "[Select a Business Entity...]",
            });
            return businessEntity.OrderBy(d => d.BusinessEntityName).ToList();
        }

        public static List<SubCategory> GetSubCategories()
        {
            var subCategories = db.SubCategories.ToList();
            subCategories.Add(new SubCategory
            {
                SubCategoryID = 0,
                SubCategoryName = "[Select a SubCategory...]",
            });
            return subCategories.OrderBy(d => d.SubCategoryName).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}