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
                new SelectListItem{ Text="Evaluada", Value="7"},
                new SelectListItem{ Text="Cancelada", Value="8" }
            }, "Value", "Text");
            ViewData["IdCompetencia"] = new SelectList(_context.competencia, "IdCompetencia", "IdCompetencia");
        ViewData["IdPersona"] = new SelectList(_context.eva_evalua_competencias_persona, "IdPersona", "Justificacion");
            return Page();
        }

        [BindProperty]
        public eva_compete_potencia_estatus eva_compete_potencia_estatus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            eva_compete_potencia_estatus.IdTipoEstatus = 26;
            eva_compete_potencia_estatus.IdUsuarioReg = "Juan";

            _context.eva_compete_potencia_estatus.Add(eva_compete_potencia_estatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}