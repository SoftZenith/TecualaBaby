using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaCompetenciasPersona
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_evalua_competencias_persona eva_evalua_competencias_persona { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_competencias_persona = await _context.eva_evalua_competencias_persona
                .Include(e => e.Competencia).SingleOrDefaultAsync(m => m.IdPersona == id);

            if (eva_evalua_competencias_persona == null)
            {
                return NotFound();
            }

            ViewData["IdGenOrigenCompe"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Asignatura Curricular", Value = "1"},
                new SelectListItem{ Text="Extraordinarias", Value="2"},
                new SelectListItem{ Text="ExtraCurricular", Value="3" }
            }, "Value", "Text");

            ViewData["IdTipoCompetencia"] = new SelectList(_context.competencia, "IdCompetencia", "IdCompetencia");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_evalua_competencias_persona).State = EntityState.Modified;

            eva_evalua_competencias_persona.IdTipoGenOrigenCompe = 70;
            eva_evalua_competencias_persona.FechaReg = DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_evalua_competencias_personaExists(eva_evalua_competencias_persona.IdPersona))
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

        private bool eva_evalua_competencias_personaExists(int id)
        {
            return _context.eva_evalua_competencias_persona.Any(e => e.IdPersona == id);
        }
    }
}
