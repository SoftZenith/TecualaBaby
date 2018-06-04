using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaOportunidades
{
    public class DetailsModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DetailsModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public eva_evalua_oportunidades eva_evalua_oportunidades { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_oportunidades = await _context.eva_evalua_oportunidades
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Metodologia).SingleOrDefaultAsync(m => m.IdOportunidad == id);

            if (eva_evalua_oportunidades == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
