using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class MomentosMetodologias
    {
        [Key]
        public int idMetodología { get; set; }
        public int idPlantilla { get; set; }
        public string descripcion { get; set; }
        public string objetivo { get; set; }
        public int secuencia { get; set; }



    }
}
