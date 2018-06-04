﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaCompetenciasResponsables
{
    public class DeleteModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DeleteModel(TecualaBaby.Models.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_evalua_competencias_responsables = await _context.eva_evalua_competencias_responsables.FindAsync(id);

            if (eva_evalua_competencias_responsables != null)
            {
                _context.eva_evalua_competencias_responsables.Remove(eva_evalua_competencias_responsables);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
