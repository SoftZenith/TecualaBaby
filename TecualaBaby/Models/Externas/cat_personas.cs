using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TecualaBaby.Models
{
    public class cat_personas
    {
        [Key]
        public int IdPersona { get; set; }

        [Required, Display(Name = "Numero de Control")]
        public string NumControl { get; set; }

        [Required, Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required, Display(Name = "Apellido Paterno")]
        public string ApPaterno { get; set; }

        [Required, Display(Name = "Apellido Materno")]
        public string ApMaterno { get; set; }
    }
}
