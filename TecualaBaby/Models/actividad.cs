using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class actividad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdActividadSugerida { get; set; }
        public int IdTipoActividadSugerida { get; set; }
        public string Nombre { get; set; }

        public List<eva_control_competencias_actividades> ControlCompetenciasActividades { get; set; }
    }
}
