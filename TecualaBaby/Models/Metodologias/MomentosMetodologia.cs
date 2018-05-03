using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class MomentosMetodologia
    {
       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required, Display(Name = "Objetivo")]
        public string Objetivo { get; set; }

        [Required, Display(Name = "Secuencia")]
        public int Secuencia { get; set; }

        public int MetodologiaId { get; set; }
        public Metodologia Metodologia { get; set; }

        public int PlantillaMetodologiaId { get; set; }
        public PlantillaMetodologia PlantillaMetodologia { get; set; }
    }
}
