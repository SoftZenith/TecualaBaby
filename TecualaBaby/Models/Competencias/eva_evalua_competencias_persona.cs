using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecualaBaby.Models.Competencias
{
    public class eva_evalua_competencias_persona
    {
        //PK
        public int IdPersona { get; set; }
        public int IdEmpSuc { get; set; }
        public int IdAsignatura { get; set; }
        //ESTATICOS
        public int IdTipoGenOrigenCompe { get; set; }
        public int IdGenOrigenCompe { get; set; }
        public string FechaReg { get; set; }
        public string FechaLimite { get; set; }
        public string Justificacion { get; set; }
        //FK
        public int IdCompetencia { get; set; }
        public int IdTipoCompetencia { get; set; }

    }
}
