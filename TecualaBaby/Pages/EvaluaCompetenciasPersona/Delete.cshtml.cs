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
    public class DeleteModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DeleteModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_evalua_competencias_persona eva_evalua_competencias_persona { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_competencias_persona = await _context.eva_evalua_competencias_persona
                .Include(e => e.Competencia).SingleOrDefaultAsync(m => m.IdPersona == id);

            if (eva_evalua_competencias_persona == null)
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

            eva_evalua_competencias_persona = await _context.eva_evalua_competencias_persona.FindAsync(id);

            if (eva_evalua_competencias_persona != null)
            {
                _context.eva_evalua_competencias_persona.Remove(eva_evalua_competencias_persona);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
