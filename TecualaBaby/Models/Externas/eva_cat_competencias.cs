using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class eva_cat_competencias
    {
        [Key]
        public int IdCompetencia { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string DesCompetencia { get; set; }

        [Required, Display(Name = "Detalle")]
        public string Detalle { get; set; }

        public int IdTipoCompetencia { get; set; }
        public eva_cat_tipo_competencias Competencias { get; set; }

        public List<eva_cat_conocimientos> Conocimientos { get; set; }
        public List<eva_evalua_competencias_persona> CompetenciasPersonas { get; set; }
        public List<eva_compete_potencia_estatus> CompetePotenciaEstatus { get; set; }
        public List<eva_evalua_oportunidades> Oportunidades { get; set; }
        public List<eva_evalua_competencias_responsables> CompetenciasResponsables { get; set; }
        public List<eva_evalua_conocimientos_oportunidad> ConocimientosOportunidad { get; set; }
        public List<eva_control_competencias_actividades> CompetenciasActividades { get; set; }

    }
}
