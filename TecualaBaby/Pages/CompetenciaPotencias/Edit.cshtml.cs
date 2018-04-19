using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.CompetenciaPotencias
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CompetenciaPotencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetenciaPotenciaExists(CompetenciaPotencia.persona))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompetenciaPotenciaExists(int id)
        {
            return _context.CompetenciaPotenciaEstatus.Any(e => e.persona == id);
        }
    }
}
