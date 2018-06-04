using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaConocimientosOportunidad
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
            ViewData["IdGenCalificacion"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Competente", Value = "1"},
                new SelectListItem{ Text="Suficiente", Value="2"},
                new SelectListItem{ Text="No Alcanzada", Value="3" }
            }, "Value", "Text");
            ViewData["IdTipoCompetencia"] = new SelectList(_context.competencia, "IdCompetencia", "IdCompetencia");
        ViewData["IdPersona"] = new SelectList(_context.eva_evalua_competencias_persona, "IdPersona", "Justificacion");
        ViewData["IdConocimiento"] = new SelectList(_context.conocimiento, "IdConocimiento", "IdConocimiento");
        ViewData["IdOportunidad"] = new SelectList(_context.eva_evalua_oportunidades, "IdOportunidad", "FechaEvaluacion");
            return Page();
        }

        [BindProperty]
        public eva_evalua_conocimientos_oportunidad eva_evalua_conocimientos_oportunidad { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            eva_evalua_conocimientos_oportunidad.FechaReg = DateTime.Now;
            eva_evalua_conocimientos_oportunidad.IdTipoGenCalificacion = 69;
            _context.eva_evalua_conocimientos_oportunidad.Add(eva_evalua_conocimientos_oportunidad);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}