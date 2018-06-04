using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaCompetenciasResponsables
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
            ViewData["IdGenResponsable"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Asignada Por", Value = "1"},
                new SelectListItem{ Text="Autorizado Por", Value="2"},
                new SelectListItem{ Text="Asesor Interno", Value="3" },
                new SelectListItem{ Text="Asesor Externo", Value = "4"},
                new SelectListItem{ Text="Tutor", Value="5"},
                new SelectListItem{ Text="Evaluador", Value="6" }
            }, "Value", "Text");
            ViewData["IdCompetencia"] = new SelectList(_context.competencia, "IdCompetencia", "IdCompetencia");
        ViewData["IdPersona"] = new SelectList(_context.eva_evalua_competencias_persona, "IdPersona", "Justificacion");
        ViewData["IdOportunidad"] = new SelectList(_context.eva_evalua_oportunidades, "IdOportunidad", "FechaEvaluacion");
            return Page();
        }

        [BindProperty]
        public eva_evalua_competencias_responsables eva_evalua_competencias_responsables { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            eva_evalua_competencias_responsables.IdTipoGenResponsable = 100;

            _context.eva_evalua_competencias_responsables.Add(eva_evalua_competencias_responsables);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}