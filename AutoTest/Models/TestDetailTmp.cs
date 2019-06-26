using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class TestDetailTmp
    {
        [Key]
        public int TestDetailTmpID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(256, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Index("SubCategory_SubCategoryName_Index",1, IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int SubCategoryID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "SubCategory")]
        [Index("SubCategory_SubCategoryName_Index",2, IsUnique = true)]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "You must enter values in {0} between {1} and {2}")]
        public int TestAnswerID { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual TestAnswer TestAnswer { get; set; }


    }
}