using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class TestAnswer
    {
        [Key]
        public int TestAnswerID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        //[MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "Valor")]
        public string Value { get; set; }

        public virtual ICollection<TestDetailTmp> TestDetailTmps { get; set; }
    }
}