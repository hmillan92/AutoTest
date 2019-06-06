using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class Lista
    {
        [Key]
        public int ListaID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "Valor")]
        public string Valor { get; set; }

        public virtual ICollection<Prueba> Pruebas { get; set; }
    }
}