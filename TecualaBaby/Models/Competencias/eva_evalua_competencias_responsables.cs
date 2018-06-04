using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class eva_evalua_competencias_responsables
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdResponsable { get; set; }

        //
        public int IdTipoGenResponsable { get; set; }

        /*Lista
         x-1 Asignado Por
         x-2 Autorizado Por
         x-3 Asesor Interno
         x-4 Asesor Externo
         x-5 Tutor
         x-6 Evaluador*/
        public int IdGenResponsable { get; set; }


        //FK
        public int IdPersona { get; set; }
        public eva_evalua_competencias_persona CompetenciasPersona { get; set; }

        public int IdCompetencia { get; set; }
        public eva_cat_competencias Competencia { get; set; }

        public int IdOportunidad { get; set; }
        public eva_evalua_oportunidades Oportunidades { get; set; }
    }
}
