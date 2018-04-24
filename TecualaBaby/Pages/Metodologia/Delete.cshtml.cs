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
        public TecualaBaby.Models.Metodologia Metodologia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Metodologia = await _context.Metodologias.SingleOrDefaultAsync(m => m.Id == id);

            if (Metodologia == null)
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

            Metodologia = await _context.Metodologias.FindAsync(id);

            if (Metodologia != null)
            {
                _context.Metodologias.Remove(Metodologia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
