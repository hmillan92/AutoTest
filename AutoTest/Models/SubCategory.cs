using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class SubCategory
    {

        [Key]
        public int SubCategoryID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "SubCategory")]
        [Index("SubCategory_SubCategoryName_Index", IsUnique = true)]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage ="You must select a {0}")]
        [Display(Name = "BusinessEntity")]
        public int BusinessEntityID { get; set; }


        public virtual BusinessEntity BusinessEntity { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<TestDetail> TestDetails { get; set; }

        public virtual ICollection<TestDetailTmp> TestDetailTmps { get; set; }
    }
}