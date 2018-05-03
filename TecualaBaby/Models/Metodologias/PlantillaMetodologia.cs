using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class PlantillaMetodologia
   
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [Required,Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public bool VersionActual { get; set; }

        public int MetodologiaId { get; set; }
        public Metodologia Metodologia { get; set; }

        public List<MomentosMetodologia> MomentosMetodologias { get; set; }
    }
}
