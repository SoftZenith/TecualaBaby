using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class Metodologia
    {
       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,Display(Name = "Clave")]
        public int Clave { get; set; }

        [Required,Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required,Display(Name = "Explicacion")]
        public string Explicacion { get; set; }

        public List<PlantillaMetodologia> PlantillaMetodologias { get; set; }
        public List<MomentosMetodologia> MomentosMetodologias { get; set; }
    }
}
