using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.Metodologia
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_cat_metodologias eva_cat_metodologias { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_cat_metodologias = await _context.eva_cat_metodologias.SingleOrDefaultAsync(m => m.IdMetodologia == id);

            if (eva_cat_metodologias == null)
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

            _context.Attach(eva_cat_metodologias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_cat_metodologiasExists(eva_cat_metodologias.IdMetodologia))
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

        private bool eva_cat_metodologiasExists(int id)
        {
            return _context.eva_cat_metodologias.Any(e => e.IdMetodologia == id);
        }
    }
}
