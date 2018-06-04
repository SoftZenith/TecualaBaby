using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class eva_cat_conocimientos
    {
        [Key]
        public int IdConocimiento { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string DesConocimiento { get; set; }

        [Required, Display(Name = "Detalle")]
        public string Detalle { get; set; }

        public int IdCompetencia { get; set; }
        public eva_cat_competencias Competencias { get; set; }

        public List<eva_evalua_conocimientos_oportunidad> ConocimientosOportunidad { get; set; }
    }
}
