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
        public eva_plantilla_metodologia eva_plantilla_metodologia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_plantilla_metodologia = await _context.eva_plantilla_metodologia
                .Include(e => e.Metodologia).SingleOrDefaultAsync(m => m.IdPlantillaMetodo == id);

            if (eva_plantilla_metodologia == null)
            {
                return NotFound();
            }
           ViewData["IdMetodologia"] = new SelectList(_context.eva_cat_metodologias, "IdMetodologia", "DesMetodologia");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_plantilla_metodologia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_plantilla_metodologiaExists(eva_plantilla_metodologia.IdPlantillaMetodo))
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

        private bool eva_plantilla_metodologiaExists(int id)
        {
            return _context.eva_plantilla_metodologia.Any(e => e.IdPlantillaMetodo == id);
        }
    }
}
