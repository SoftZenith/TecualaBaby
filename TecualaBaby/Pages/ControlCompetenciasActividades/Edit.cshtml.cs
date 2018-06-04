using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.ControlCompetenciasActividades
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_control_competencias_actividades eva_control_competencias_actividades { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_control_competencias_actividades = await _context.eva_control_competencias_actividades
                .Include(e => e.Actividad)
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Oportunidades).SingleOrDefaultAsync(m => m.IdActividad == id);

            if (eva_control_competencias_actividades == null)
            {
                return NotFound();
            }
           ViewData["IdTipoActividadSug"] = new SelectList(_context.actividad, "Id", "Id");
           ViewData["IdCompetencia"] = new SelectList(_context.competencia, "IdCompetencia", "IdCompetencia");
           ViewData["IdPersona"] = new SelectList(_context.eva_evalua_competencias_persona, "IdPersona", "Justificacion");
           ViewData["IdOportunidad"] = new SelectList(_context.eva_evalua_oportunidades, "IdOportunidad", "FechaEvaluacion");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_control_competencias_actividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_control_competencias_actividadesExists(eva_control_competencias_actividades.IdActividad))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool eva_control_competencias_actividadesExists(int id)
        {
            return _context.eva_control_competencias_actividades.Any(e => e.IdActividad == id);
        }
    }
}
