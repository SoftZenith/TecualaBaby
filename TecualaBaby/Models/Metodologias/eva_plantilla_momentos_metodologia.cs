using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class eva_plantilla_momentos_metodologia
    {
       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMomento { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string DesMomento { get; set; }

        [Required, Display(Name = "Objetivo")]
        public string Objetivo { get; set; }

        [Required, Display(Name = "Secuencia")]
        public int Secuencia { get; set; }

        public int IdMetodologia { get; set; }
        public eva_cat_metodologias Metodologia { get; set; }

        public int IdPlantillaMetodo { get; set; }
        public eva_plantilla_metodologia PlantillaMetodologia { get; set; }
    }
}
