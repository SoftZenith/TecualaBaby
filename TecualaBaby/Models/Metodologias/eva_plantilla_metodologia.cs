using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class eva_plantilla_metodologia
   
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlantillaMetodo { get; set; }
       
        [Required,Display(Name = "Descripcion")]
        public string DesPlantillaMetodo { get; set; }

        [Required, Display(Name = "Fecha Registro" )]
        public DateTime FechaReg { get; set; }

        [Required, Display(Name = "Version Actual")]
        public string VersionActual { get; set; }

        public int IdMetodologia { get; set; }
        public eva_cat_metodologias Metodologia { get; set; }

        public List<eva_plantilla_momentos_metodologia> MomentosMetodologias { get; set; }
    }
}
