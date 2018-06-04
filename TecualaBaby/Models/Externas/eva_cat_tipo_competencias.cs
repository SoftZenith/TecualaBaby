using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class eva_cat_tipo_competencias
    {
        [Key]
        public int IdTipoCompetencia { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string DesTipoCompetencia { get; set; }

        [Required, Display(Name = "Detalle")]
        public string Detalle { get; set; }

        public List<eva_cat_competencias> Competencias { get; set; }
        public List<eva_evalua_competencias_persona> CompetenciasPersonas { get; set; }
        public List<eva_evalua_conocimientos_oportunidad> ConocimientosOportunidad { get; set; }
    }
}
