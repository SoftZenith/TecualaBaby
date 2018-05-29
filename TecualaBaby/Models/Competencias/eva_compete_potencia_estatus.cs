using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TecualaBaby.Models
{
    public class eva_compete_potencia_estatus
    {
        
        public int IdPersona  { get; set; }
        public int IdCompetencia { get; set; }
        public int IdEstatusDet { get; set; }
        public int IdTipoEstatus { get; set; }
        public string FechaEstatus { get; set; }
        public string Actual { get; set; }
        public string Observacion { get; set; }
        public string IdUsuarioReg { get; set; }
    }
}
