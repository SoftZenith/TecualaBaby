using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class competencia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCompetencia { get; set; }
        public int IdTipoCompetencia { get; set; }
        public string Nombre { get; set; }

        public List<eva_evalua_competencias_persona> CompetenciasPersonas { get; set; }
        public List<eva_compete_potencia_estatus> CompetePotenciaEstatus { get; set; }
        public List<eva_evalua_oportunidades> Oportunidades { get; set; }
        public List<eva_evalua_competencias_responsables> CompetenciasResponsables { get; set; }
        public List<eva_evalua_conocimientos_oportunidad> ConocimientosOportunidad { get; set; }
        public List<eva_control_competencias_actividades> CompetenciasActividades { get; set; }
    }
}
