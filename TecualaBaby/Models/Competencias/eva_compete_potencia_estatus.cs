using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class eva_compete_potencia_estatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstatusDet { get; set; }

        [Required, Display(Name = "IdTipoEstatus")]
        public int IdTipoEstatus { get; set; }

        /*Lista
         * 26 - 1 Asignada
         * 26 - 7 Evaluada
         * 26 - 8 Cancelada
         */
        [Required,Display(Name = "IdEstatus")]
        public int IdEstatus { get; set; }

        [Required, Display(Name = "Fecha Estatus")]
        public DateTime FechaEstatus { get; set; }

        [Required, Display(Name = "Actual")]
        public bool Actual { get; set; }

        [Required, Display(Name = "Observaciones")]
        public string Observacion { get; set; }

       
        public string IdUsuarioReg { get; set; }

        public int IdPersona { get; set; }
        public eva_evalua_competencias_persona CompetenciasPersona { get; set; }

        public int IdCompetencia { get; set; }
        public eva_cat_competencias Competencia { get; set; }

    }
}
