using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }

        public string Nombre { get; set; }

        public int Edad { get; set; }
    }
}