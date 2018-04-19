using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TecualaBaby.Models
{
    public class CompetenciaPotencia
    {
        [Key]
        public int persona  { get; set; }
        public int competencia { get; set; }
        public int idEstatus { get; set; }
        public int idTipoEstatus { get; set; }
        public DateTime fechaEstatus { get; set; }
        public char actual { get; set; }
        public string observacion { get; set; }
        public string idUsuarioReg { get; set; }
    }
}
