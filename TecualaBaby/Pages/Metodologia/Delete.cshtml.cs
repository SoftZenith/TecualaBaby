using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.Metodologia
{
    public class DeleteModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DeleteModel(TecualaBaby.Models.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_cat_metodologias = await _context.eva_cat_metodologias.FindAsync(id);

            if (eva_cat_metodologias != null)
            {
                _context.eva_cat_metodologias.Remove(eva_cat_metodologias);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
