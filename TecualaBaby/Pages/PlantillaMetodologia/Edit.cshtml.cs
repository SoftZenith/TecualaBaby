using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.PlantillaMetodologia
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TecualaBaby.Models.PlantillaMetodologia PlantillaMetodologia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PlantillaMetodologia = await _context.PlantillaMetodologias
                .Include(p => p.Metodologia).SingleOrDefaultAsync(m => m.Id == id);

            if (PlantillaMetodologia == null)
            {
                return NotFound();
            }
           ViewData["MetodologiaId"] = new SelectList(_context.Metodologias, "Id", "Descripcion");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlantillaMetodologia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantillaMetodologiaExists(PlantillaMetodologia.Id))
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

        private bool PlantillaMetodologiaExists(int id)
        {
            return _context.PlantillaMetodologias.Any(e => e.Id == id);
        }
    }
}
