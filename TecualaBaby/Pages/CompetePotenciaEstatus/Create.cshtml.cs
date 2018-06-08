using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.CompetePotenciaEstatus
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
            ViewData["IdEstatus"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Asignada", Value = "1"},
                new SelectListItem{ Text="Evaluada", Value= "2"},
                new SelectListItem{ Text="Cancelada", Value= "3" }

            }, "Value", "Text");
            idcompe = IdCompe;
            idpersona = IdPerso;
            usuario = NombreC;
            return Page();
        }

        [BindProperty]
        public eva_compete_potencia_estatus eva_compete_potencia_estatus { get; set; }

        [TempData]
        public string NombreC { get; set; }
        [TempData]
        public string NumeroControl { get; set; }
        [TempData]
        public string NCompe { get; set; }
        [TempData]
        public int IdCompe { get; set; }
        [TempData]
        public int IdPerso { get; set; }

        public static int idcompe;
        public static int idpersona;
        public static string usuario;

        public async Task<IActionResult> OnPostAsync()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid)
            {
                return Page();
            }


            eva_compete_potencia_estatus.IdCompetencia = idcompe;
            eva_compete_potencia_estatus.IdPersona = idpersona;
            eva_compete_potencia_estatus.IdTipoEstatus = 7;
            eva_compete_potencia_estatus.IdUsuarioReg = usuario;
            eva_compete_potencia_estatus.FechaEstatus = DateTime.Now;
            _context.eva_compete_potencia_estatus.Add(eva_compete_potencia_estatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = idpersona, competencia = idcompe} );
        }
    }
}