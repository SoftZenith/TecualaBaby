using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaCompetenciasResponsables
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_evalua_competencias_responsables eva_evalua_competencias_responsables { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_competencias_responsables = await _context.eva_evalua_competencias_responsables
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Oportunidades).SingleOrDefaultAsync(m => m.IdResponsable == id);

            if (eva_evalua_competencias_responsables == null)
            {
                return NotFound();
            }
            ViewData["IdGenResponsable"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Asignada Por", Value = "1"},
                new SelectListItem{ Text="Autorizado Por", Value="2"},
                new SelectListItem{ Text="Asesor Interno", Value="3" },
                new SelectListItem{ Text="Asesor Externo", Value = "4"},
                new SelectListItem{ Text="Tutor", Value="5"},
                new SelectListItem{ Text="Evaluador", Value="6" }
            }, "Value", "Text");
            ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "DesCompetencia");
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

            _context.Attach(eva_evalua_competencias_responsables).State = EntityState.Modified;

            eva_evalua_competencias_responsables.IdTipoGenResponsable = 16;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_evalua_competencias_responsablesExists(eva_evalua_competencias_responsables.IdResponsable))
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

        private bool eva_evalua_competencias_responsablesExists(int id)
        {
            return _context.eva_evalua_competencias_responsables.Any(e => e.IdResponsable == id);
        }
    }
}
