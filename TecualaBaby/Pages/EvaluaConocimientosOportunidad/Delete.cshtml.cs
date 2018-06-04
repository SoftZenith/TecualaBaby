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
    public class DeleteModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DeleteModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_evalua_conocimientos_oportunidad eva_evalua_conocimientos_oportunidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_conocimientos_oportunidad = await _context.eva_evalua_conocimientos_oportunidad
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Conocimiento)
                .Include(e => e.Oportunidades).SingleOrDefaultAsync(m => m.IdConocimientoDet == id);

            if (eva_evalua_conocimientos_oportunidad == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_conocimientos_oportunidad = await _context.eva_evalua_conocimientos_oportunidad.FindAsync(id);

            if (eva_evalua_conocimientos_oportunidad != null)
            {
                _context.eva_evalua_conocimientos_oportunidad.Remove(eva_evalua_conocimientos_oportunidad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
