using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.CompetenciaPotencias
{
    public class DeleteModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DeleteModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompetenciaPotencia CompetenciaPotencia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompetenciaPotencia = await _context.CompetenciaPotenciaEstatus.SingleOrDefaultAsync(m => m.persona == id);

            if (CompetenciaPotencia == null)
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

            CompetenciaPotencia = await _context.CompetenciaPotenciaEstatus.FindAsync(id);

            if (CompetenciaPotencia != null)
            {
                _context.CompetenciaPotenciaEstatus.Remove(CompetenciaPotencia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
