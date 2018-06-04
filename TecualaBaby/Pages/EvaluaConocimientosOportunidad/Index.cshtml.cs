using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaConocimientosOportunidad
{
    public class IndexModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public IndexModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_evalua_conocimientos_oportunidad> eva_evalua_conocimientos_oportunidad { get;set; }

        public async Task OnGetAsync()
        {
            eva_evalua_conocimientos_oportunidad = await _context.eva_evalua_conocimientos_oportunidad
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Conocimiento)
                .Include(e => e.Oportunidades).ToListAsync();
        }
    }
}
