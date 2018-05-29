using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class eva_cat_metodologias
    {
       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMetodologia { get; set; }

        [Required,Display(Name = "Clave")]
        public string Clave { get; set; }

        [Required,Display(Name = "Descripcion")]
        public string DesMetodologia { get; set; }

        [Required,Display(Name = "Explicacion")]
        public string Explicacion { get; set; }

        public List<eva_plantilla_metodologia> PlantillaMetodologia{ get; set; }
//        public List<MomentosMetodologia> MomentosMetodologias { get; set; }
    }
}
