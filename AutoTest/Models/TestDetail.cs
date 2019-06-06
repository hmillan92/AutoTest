using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class TestDetail
    {
        [Key]
        public int TestDetailID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Test Header")]
        public int TestHeaderID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "User")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "SubCategory")]
        public int SubCategoryID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "SubCategory")]
        [Index("SubCategory_SubCategoryName_Index", IsUnique = true)]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "You must enter values in {0} between {1} and {2}")]
        public double Value { get; set; }

        public virtual TestHeader TestHeader { get; set; }

        public virtual User User { get; set; }

        public virtual SubCategory SubCategory { get; set; }

    }
}