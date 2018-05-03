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
        ViewData["MetodologiaId"] = new SelectList(_context.Metodologias, "Id", "Descripcion");
        ViewData["PlantillaMetodologiaId"] = new SelectList(_context.PlantillaMetodologias, "Id", "Descripcion");
            return Page();
        }

        [BindProperty]
        public MomentosMetodologia MomentosMetodologia { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MomentosMetodologia.Add(MomentosMetodologia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}