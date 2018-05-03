using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.MomentoMetodologia
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MomentosMetodologia MomentosMetodologia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MomentosMetodologia = await _context.MomentosMetodologia
                .Include(m => m.Metodologia)
                .Include(m => m.PlantillaMetodologia).SingleOrDefaultAsync(m => m.Id == id);

            if (MomentosMetodologia == null)
            {
                return NotFound();
            }
           ViewData["MetodologiaId"] = new SelectList(_context.Metodologias, "Id", "Descripcion");
           ViewData["PlantillaMetodologiaId"] = new SelectList(_context.PlantillaMetodologias, "Id", "Descripcion");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MomentosMetodologia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MomentosMetodologiaExists(MomentosMetodologia.Id))
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

        private bool MomentosMetodologiaExists(int id)
        {
            return _context.MomentosMetodologia.Any(e => e.Id == id);
        }
    }
}
