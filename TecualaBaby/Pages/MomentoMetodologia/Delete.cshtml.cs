using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.MomentoMetodologia
{
    public class DeleteModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DeleteModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_plantilla_momentos_metodologia eva_plantilla_momentos_metodologia { get; set; }
        [TempData]
        public string idplantilla { get; set; }
        [TempData]
        public string idmetodologia { get; set; }
        [TempData]
        public int idp { get; set; }
        [TempData]
        public int idm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_plantilla_momentos_metodologia = await _context.eva_plantilla_momentos_metodologia
                .Include(e => e.Metodologia)
                .Include(e => e.PlantillaMetodologia).SingleOrDefaultAsync(m => m.IdMomento == id);

            if (eva_plantilla_momentos_metodologia == null)
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

            eva_plantilla_momentos_metodologia = await _context.eva_plantilla_momentos_metodologia.FindAsync(id);

            if (eva_plantilla_momentos_metodologia != null)
            {
                _context.eva_plantilla_momentos_metodologia.Remove(eva_plantilla_momentos_metodologia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
