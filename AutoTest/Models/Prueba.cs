using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class Prueba
    {
        [Key]
        public int PruebaID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "Pregunta")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int ListaID { get; set; }


        public virtual Lista Lista { get; set; }
    }
}