using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class AddSubCategoryView
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int SubCategoryID { get; set; }
    }
}