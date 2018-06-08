using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
            IdMetodo = idm;
            IdPlantilla = idp;
            return Page();
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

        public static int IdMetodo;
        public static int IdPlantilla;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            eva_plantilla_momentos_metodologia.IdMetodologia = IdMetodo;
            eva_plantilla_momentos_metodologia.IdPlantillaMetodo = IdPlantilla;

            _context.eva_plantilla_momentos_metodologia.Add(eva_plantilla_momentos_metodologia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new {id = IdPlantilla });
        }

       
    }
}