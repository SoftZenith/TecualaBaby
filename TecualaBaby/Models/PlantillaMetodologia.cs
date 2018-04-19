using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class PlantillaMetodologia
   
    {
        public int Id { get; set; }
        public int IdMetodologia { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool VersionActual { get; set; }
    }
}
