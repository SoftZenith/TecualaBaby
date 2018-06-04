using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class eva_evalua_conocimientos_oportunidad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConocimientoDet { get; set; }

        //x
        public int IdTipoGenCalificacion { get; set; }

        /*Lista
         * x-1 Competente
         * x-2 Suficiente
         * x-3 No Alcanzado
         */
        public int IdGenCalificacion { get; set; }

        [Required, Display(Name = "Calificacion")]
        public float Calificacion { get; set; }

        [Required, Display(Name = "Fecha Registro")]
        public DateTime FechaReg { get; set; }

        [Required, Display(Name = "Fecha Evaluacion")]
        public DateTime FechaEvaluacion { get; set; }

        //FK
        public int IdPersona { get; set; }
        public eva_evalua_competencias_persona CompetenciasPersona { get; set; }

        public int IdCompetencia { get; set; }
        public eva_cat_competencias Competencia { get; set; }

        public int IdTipoCompetencia { get; set; }
        public eva_cat_tipo_competencias TipoCompetencias { get; set; }

        public int IdOportunidad { get; set; }
        public eva_evalua_oportunidades Oportunidades { get; set; }

        public int IdConocimiento { get; set; }
        public eva_cat_conocimientos Conocimiento { get; set; }
    }
}
