using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class eva_control_competencias_actividades
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActividad { get; set; }

        [Required, Display(Name = "Tema")]
        public string Tema { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string DesActividad { get; set; }

        [Required, Display(Name = "Sugerido por")]
        public bool SugeridaPor { get; set; }

        [Required, Display(Name = "Eligio Alumno")]
        public bool EligioAlumno { get; set; }


        /*Lista
         * x-1 Exposicion
         * x-2 Ensayo
         * x-3 Dramatizacion
         * x-4 VideoTutorial
         * x-5 Tutorial
         * x-6 Software
         * x-7 Taller
         * x-8 Curso
         * x-9 Maestria
         * x-10 doctorado
         */
        public int IdActividadSugerida { get; set; }

        //x
        public int IdTipoActividadSug { get; set; }
        public actividad Actividad { get; set; }

        //Fk
        public int IdPersona { get; set; }
        public eva_evalua_competencias_persona CompetenciasPersona { get; set; }

        public int IdCompetencia { get; set; }
        public competencia Competencia { get; set; }

        public int IdOportunidad { get; set; }
        public eva_evalua_oportunidades Oportunidades { get; set; }
    }
}
