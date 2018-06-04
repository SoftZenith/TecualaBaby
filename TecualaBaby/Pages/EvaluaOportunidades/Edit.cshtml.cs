using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaOportunidades
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_evalua_oportunidades eva_evalua_oportunidades { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_oportunidades = await _context.eva_evalua_oportunidades
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Metodologia).SingleOrDefaultAsync(m => m.IdOportunidad == id);

            if (eva_evalua_oportunidades == null)
            {
                return NotFound();
            }
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_evalua_oportunidades).State = EntityState.Modified;

            eva_evalua_oportunidades.FechaReg = DateTime.Now;
            eva_evalua_oportunidades.IdTipoGenCalificacion = 69;
            eva_evalua_oportunidades.IdTipoGenOportunidad = 71;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_evalua_oportunidadesExists(eva_evalua_oportunidades.IdOportunidad))
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

        private bool eva_evalua_oportunidadesExists(int id)
        {
            return _context.eva_evalua_oportunidades.Any(e => e.IdOportunidad == id);
        }
    }
}
