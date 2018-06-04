﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecualaBaby.Models
{
    public class eva_cat_tipo_actividades_sugeridas
    {
        [Key]
        public int IdTipoActividadSug { get; set; }

        [Required, Display(Name = "Descripcion")]
        public string DesTipoActividadSug { get; set; }

        public List<eva_cat_actividades_sugeridas> ActividadesSugeridas { get; set; }
        public List<eva_control_competencias_actividades> CompetenciasActividades { get; set; }
    }
}
