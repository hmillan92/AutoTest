using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class BusinessEntity
    {
        [Key]
        public int BusinessEntityID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage ="The field {0} must be maximun {1} characters")]
        [Display(Name = "BussinessEntity", Prompt = "[Select a product...]")]
        [Index("BusinessEntity_BusinessEntityName_Index", IsUnique = true)]
        public string BusinessEntityName { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}