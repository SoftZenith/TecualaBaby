using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.ControlCompetenciasActividades
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
        ViewData["IdTipoActividadSug"] = new SelectList(_context.eva_cat_tipo_Actividades_sugeridas, "IdTipoActividadSug", "DesTipoActividadSug");
        ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "DesCompetencia");
        ViewData["IdPersona"] = new SelectList(_context.eva_evalua_competencias_persona, "IdPersona", "Justificacion");
        ViewData["IdOportunidad"] = new SelectList(_context.eva_evalua_oportunidades, "IdOportunidad", "FechaEvaluacion");
            return Page();
        }

        [BindProperty]
        public eva_control_competencias_actividades eva_control_competencias_actividades { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.eva_control_competencias_actividades.Add(eva_control_competencias_actividades);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}