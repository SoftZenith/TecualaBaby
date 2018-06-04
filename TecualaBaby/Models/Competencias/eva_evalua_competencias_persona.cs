using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class eva_evalua_competencias_persona
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        [Required, Display(Name = "Empleado Sucursal")]
        public int IdEmpSuc { get; set; }

        [Required, Display(Name = "Asignatura")]
        public int IdAsignatura { get; set; }

        //70 No se muestra
        [Required, Display(Name = "IdTipoGenOrigenCompe")]
        public int IdTipoGenOrigenCompe { get; set; }

        /*70-1 Asignatura Curricular
         * 70-2 ExtraOrdinarias (Curricular)
         * 70-3 ExtraCurricular
         */
        [Required, Display(Name = "IdGenOrigenCompete")]
        public int IdGenOrigenCompe { get; set; }

        [Required, Display(Name = "Fecha Registro")]
        public DateTime FechaReg { get; set; }

        [Required, Display(Name = "Fecha Limite")]
        public DateTime FechaLimite { get; set; }

        [Required, Display(Name = "Justificacion")]
        public string Justificacion { get; set; }
        
        //FK
        public int IdCompetencia { get; set; }
        public int IdTipoCompetencia { get; set; }
        public competencia Competencia { get; set; }

        public List<eva_compete_potencia_estatus> CompetePotenciaEstatus { get; set; }
        public List<eva_evalua_oportunidades> Oportunidades { get; set; }
        public List<eva_evalua_competencias_responsables> CompetenciasResponsables { get; set; }
        public List<eva_evalua_conocimientos_oportunidad> ConocimientosOportunidad { get; set; }
        public List<eva_control_competencias_actividades> CompetenciasActividades { get; set; }

    }
}
