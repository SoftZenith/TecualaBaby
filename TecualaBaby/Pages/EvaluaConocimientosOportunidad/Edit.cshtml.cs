using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaConocimientosOportunidad
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_evalua_conocimientos_oportunidad eva_evalua_conocimientos_oportunidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_conocimientos_oportunidad = await _context.eva_evalua_conocimientos_oportunidad
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Conocimiento)
                .Include(e => e.Oportunidades).SingleOrDefaultAsync(m => m.IdConocimientoDet == id);

            if (eva_evalua_conocimientos_oportunidad == null)
            {
                return NotFound();
            }
            ViewData["IdGenCalificacion"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Competente", Value = "1"},
                new SelectListItem{ Text="Suficiente", Value="2"},
                new SelectListItem{ Text="No Alcanzada", Value="3" }
            }, "Value", "Text");
            ViewData["IdTipoCompetencia"] = new SelectList(_context.eva_cat_tipo_competencias, "IdTipoCompetencia", "DesTipoCompetencia");
           ViewData["IdPersona"] = new SelectList(_context.eva_evalua_competencias_persona, "IdPersona", "Justificacion");
           ViewData["IdConocimiento"] = new SelectList(_context.eva_cat_conocimientos, "IdConocimiento", "DesConocimiento");
           ViewData["IdOportunidad"] = new SelectList(_context.eva_evalua_oportunidades, "IdOportunidad", "FechaEvaluacion");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_evalua_conocimientos_oportunidad).State = EntityState.Modified;
            eva_evalua_conocimientos_oportunidad.FechaReg = DateTime.Now;
            eva_evalua_conocimientos_oportunidad.IdTipoGenCalificacion = 69;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_evalua_conocimientos_oportunidadExists(eva_evalua_conocimientos_oportunidad.IdConocimientoDet))
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

        private bool eva_evalua_conocimientos_oportunidadExists(int id)
        {
            return _context.eva_evalua_conocimientos_oportunidad.Any(e => e.IdConocimientoDet == id);
        }
    }
}
