using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.MomentoMetodologia
{
    public class CreateModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public CreateModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdMetodologia"] = new SelectList(_context.eva_cat_metodologias, "IdMetodologia", "DesMetodologia");
        ViewData["IdPlantillaMetodo"] = new SelectList(_context.eva_plantilla_metodologia, "IdPlantillaMetodologia", "DesPlantillaMetodo");
            return Page();
        }

        [BindProperty]
        public eva_plantilla_momentos_metodologia eva_plantilla_momentos_metodologia { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.eva_plantilla_momentos_metodologia.Add(eva_plantilla_momentos_metodologia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}