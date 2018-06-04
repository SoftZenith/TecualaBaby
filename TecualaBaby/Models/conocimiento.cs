using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models
{
    public class conocimiento
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConocimiento { get; set; }
        public int IdTipoConocimiento { get; set; }
        public string Nombre { get; set; }

        public List<eva_evalua_conocimientos_oportunidad> ConocimientosOportunidad { get; set; }
    }
}
