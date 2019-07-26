using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class TestAnswer
    {
        [Key]
        public int TestAnswerID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(3, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "Values")]
        [Index("Value_Index", IsUnique = true)]
        [RegularExpression("^\\d+$", ErrorMessage = "You can only enter integer numbers.")]
        public string Value { get; set; }

        public virtual ICollection<TestSummaryDetailTmp> TestSummaryDetailTmps { get; set; }

        public virtual ICollection<TestQuestionDetailTmp> TestQuestionDetailTmps { get; set; }


        //public virtual ICollection<TestDetail> TestDetail { get; set; }
    }
}