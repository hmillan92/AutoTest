using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
        public class Question
        {

            [Key]
            public int QuestionID { get; set; }

            [Required(ErrorMessage = "The field {0} is required")]
            [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
            [DataType(DataType.MultilineText)]
            [Display(Name = "Question")]
            public string QuestionName { get; set; }

            [Required(ErrorMessage = "The field {0} is required")]
            [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
            public int BusinessEntityID { get; set; }

            [Required(ErrorMessage = "The field {0} is required")]
            [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
            [Display(Name = "SubCategory")]
            public int SubCategoryID { get; set; }

            public virtual BusinessEntity BusinessEntity { get; set; }

            public virtual SubCategory SubCategory { get; set; }

            public virtual ICollection<TestQuestionDetailTmp> TestQuestionDetailTmps { get; set; }


    }

}