using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaOportunidades
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

            ViewData["IdGenOportunidad"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Primer Ordinario", Value = "1"},
                new SelectListItem{ Text="Segundo Ordinario", Value="2"},
                new SelectListItem{ Text="Extraordinario", Value="3" },
                new SelectListItem{ Text="Repeticion Primer Ordinario", Value = "4"},
                new SelectListItem{ Text="Repeticion Segundo Ordinario", Value="5"},
                new SelectListItem{ Text="Repeticion Extraordinario", Value="6" },
                new SelectListItem{ Text="Especial", Value="7"}
            }, "Value", "Text");

            ViewData["IdCompetencia"] = new SelectList(_context.competencia, "IdCompetencia", "IdCompetencia");
        ViewData["IdPersona"] = new SelectList(_context.eva_evalua_competencias_persona, "IdPersona", "Justificacion");
        ViewData["IdMetodologia"] = new SelectList(_context.eva_cat_metodologias, "IdMetodologia", "Clave");
            return Page();
        }

        [BindProperty]
        public eva_evalua_oportunidades eva_evalua_oportunidades { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            eva_evalua_oportunidades.IdTipoGenCalificacion = 69;
            eva_evalua_oportunidades.IdTipoGenOportunidad = 71;
            eva_evalua_oportunidades.FechaReg = DateTime.Now;
            _context.eva_evalua_oportunidades.Add(eva_evalua_oportunidades);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}