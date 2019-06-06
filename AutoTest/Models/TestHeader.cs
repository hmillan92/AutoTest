using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class TestHeader
    {
        [Key]
        public int TestHeaderID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "User")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "State")]
        public int StateID { get; set; }

        public virtual User User { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<TestDetail> TestDetails { get; set; }

    }
}