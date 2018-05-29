using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.PlantillaMetodologia
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
            return Page();
        }

        [BindProperty]
        public eva_plantilla_metodologia eva_plantilla_metodologia { get; set; }

    

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string va = Request.Form["va"];
            int id = eva_plantilla_metodologia.IdMetodologia;

            if (va!= null)
            {
                (from p in _context.eva_plantilla_metodologia
                 where p.IdMetodologia == id
                 select p).ToList().ForEach(x => x.VersionActual = "N");
                _context.SaveChanges(); 
                
                eva_plantilla_metodologia.VersionActual = va;

            }
            else {
                eva_plantilla_metodologia.VersionActual = "N";
            }
            
            eva_plantilla_metodologia.FechaReg = DateTime.Now;
            
            _context.eva_plantilla_metodologia.Add(eva_plantilla_metodologia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}