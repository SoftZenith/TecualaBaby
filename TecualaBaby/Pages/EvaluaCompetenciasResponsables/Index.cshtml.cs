using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaCompetenciasResponsables
{
    public class IndexModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public IndexModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_evalua_competencias_responsables> eva_evalua_competencias_responsables { get;set; }

        public async Task OnGetAsync()
        {
            eva_evalua_competencias_responsables = await _context.eva_evalua_competencias_responsables
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Oportunidades).ToListAsync();
        }
    }
}
