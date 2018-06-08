using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.CompetePotenciaEstatus
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_compete_potencia_estatus eva_compete_potencia_estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_compete_potencia_estatus = await _context.eva_compete_potencia_estatus
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona).SingleOrDefaultAsync(m => m.IdEstatusDet == id);

            if (eva_compete_potencia_estatus == null)
            {
                return NotFound();
            }
            ViewData["IdEstatus"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Asignada", Value = "1"},
                new SelectListItem{ Text="Evaluada", Value= "2"},
                new SelectListItem{ Text="Cancelada", Value= "3" }

            }, "Value", "Text");
            ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "DesCompetencia");
           ViewData["IdPersona"] = new SelectList(_context.eva_evalua_competencias_persona, "IdPersona", "Justificacion");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
      
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_compete_potencia_estatus).State = EntityState.Modified;
            eva_compete_potencia_estatus.IdTipoEstatus = 7;
            eva_compete_potencia_estatus.IdUsuarioReg = "Juan";
            eva_compete_potencia_estatus.FechaEstatus = DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_compete_potencia_estatusExists(eva_compete_potencia_estatus.IdEstatusDet))
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

        private bool eva_compete_potencia_estatusExists(int id)
        {
            return _context.eva_compete_potencia_estatus.Any(e => e.IdEstatusDet == id);
        }
    }
}
