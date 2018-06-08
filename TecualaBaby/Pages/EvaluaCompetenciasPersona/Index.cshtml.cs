using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaCompetenciasPersona
{
    public class IndexModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public IndexModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_evalua_competencias_persona> eva_evalua_competencias_persona { get;set; }

        [TempData]
        public string NombreC { get; set; }
        [TempData]
        public string NumeroControl { get; set; }

        public async Task OnGetAsync(int? id)
        {
            eva_evalua_competencias_persona = await _context.eva_evalua_competencias_persona
                .Include(e => e.Competencia)
                .Where(x => x.IdPersona == id).ToListAsync();

            NombreC = (from p in _context.cat_personas
                       where p.IdPersona == id
                       select p.Nombre).ToArray().FirstOrDefault();

            NombreC = NombreC+"  "+ (from p in _context.cat_personas
                                     where p.IdPersona == id
                                     select p.ApMaterno).ToArray().FirstOrDefault();

            NombreC = NombreC + "  " + (from p in _context.cat_personas
                                        where p.IdPersona == id
                                        select p.ApMaterno).ToArray().FirstOrDefault();

            NumeroControl = (from p in _context.cat_personas
                             where p.IdPersona == id
                             select p.NumControl).ToArray().FirstOrDefault();

        }
    }
}
