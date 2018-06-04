using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class eva_evalua_oportunidades
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOportunidad { get; set; }

        //69
        public int IdTipoGenCalificacion { get; set; }

        /*Lista
         6-1 Competente
         6-2 Suficiente
         6-3 No alcanzada*/
        public int IdGenCalificacion { get; set; }

        [Required, Display(Name = "Calificacion")]
        public float Calificacion { get; set; }

        //71
        public int IdTipoGenOportunidad { get; set; }

        /*Lista
         * 71-1 Primer Ordinario
         * 71-2 Segundo Ordinario
         * 71-3 Extraordinario
         * 71-4 Repeticion PrimerOrdinario
         * 71-5 Repeticion Segundoordinario
         * 71-6 Reperticion Extraordinario
         * 71-7 Especial
         */
        public int IdGenOportunidad { get; set; }

        [Required, Display(Name = "Fecha Registro")]
        public DateTime FechaReg { get; set; }

        [Required, Display(Name = "Fecha Evalucion")]
        public DateTime FechaEvaluacion { get; set; }


        //FK
        public int IdMetodologia { get; set; }
        public eva_cat_metodologias Metodologia { get; set; }

        public int IdCompetencia { get; set; }
        public competencia Competencia { get; set; }

        public int IdPersona { get; set; }
        public eva_evalua_competencias_persona CompetenciasPersona { get; set; }
       
        public List<eva_evalua_competencias_responsables> CompetenciasResponsables { get; set; }
        public List<eva_evalua_conocimientos_oportunidad> ConocimientosOportunidad { get; set; }
        public List<eva_control_competencias_actividades> CompetenciasActividades { get; set; }
    }
}
