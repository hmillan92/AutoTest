using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "State")]
        [Index("StateName_Index", IsUnique = true)]
        public string StateName { get; set; }

        public virtual ICollection<TestHeader> TestHeaders { get; set; }
    }
}