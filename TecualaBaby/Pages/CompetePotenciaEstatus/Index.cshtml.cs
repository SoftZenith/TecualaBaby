using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.CompetePotenciaEstatus
{
    public class IndexModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public IndexModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_compete_potencia_estatus> eva_compete_potencia_estatus { get;set; }

        [TempData]
        public string NombreC { get; set; }
        [TempData]
        public string NumeroControl { get; set; }
        [TempData]
        public string NCompe { get; set; }
        [TempData]
        public int IdCompe { get; set; }
        [TempData]
        public int IdPerso { get; set; }

        public async Task OnGetAsync(int? id, int? competencia)
        {
            eva_compete_potencia_estatus = await _context.eva_compete_potencia_estatus
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Where(x => x.IdPersona == id && x.IdCompetencia == competencia).ToListAsync();

            NombreC = (from p in _context.cat_personas
                       where p.IdPersona == id
                       select p.Nombre).ToArray().FirstOrDefault();

            NombreC = NombreC + "  " + (from p in _context.cat_personas
                                        where p.IdPersona == id
                                        select p.ApMaterno).ToArray().FirstOrDefault();

            NombreC = NombreC + "  " + (from p in _context.cat_personas
                                        where p.IdPersona == id
                                        select p.ApMaterno).ToArray().FirstOrDefault();

            NumeroControl = (from p in _context.cat_personas
                             where p.IdPersona == id
                             select p.NumControl).ToArray().FirstOrDefault();

            NCompe = (from p in _context.eva_cat_competencias
                      where p.IdCompetencia == competencia
                      select p.DesCompetencia).ToArray().FirstOrDefault();

            IdCompe = (from p in _context.eva_cat_competencias
                      where p.IdCompetencia == competencia
                      select p.IdCompetencia).ToArray().FirstOrDefault();

            IdPerso = (from p in _context.eva_evalua_competencias_persona
                       where p.IdPersona == id
                       select p.IdPersona).ToArray().FirstOrDefault();

        }
    }
}
