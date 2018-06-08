﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.MomentoMetodologia
{
    public class EditModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public EditModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_plantilla_momentos_metodologia eva_plantilla_momentos_metodologia { get; set; }
        [TempData]
        public string idplantilla { get; set; }
        [TempData]
        public string idmetodologia { get; set; }
        [TempData]
        public int idp { get; set; }
        [TempData]
        public int idm { get; set; }

        public static int IdMetodo;
        public static int IdPlantilla;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IdMetodo = idm;
            IdPlantilla = idp;

            eva_plantilla_momentos_metodologia = await _context.eva_plantilla_momentos_metodologia
                .Include(e => e.Metodologia)
                .Include(e => e.PlantillaMetodologia).SingleOrDefaultAsync(m => m.IdMomento == id);

            if (eva_plantilla_momentos_metodologia == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_plantilla_momentos_metodologia).State = EntityState.Modified;
            eva_plantilla_momentos_metodologia.IdMetodologia = IdMetodo;
            eva_plantilla_momentos_metodologia.IdPlantillaMetodo = IdPlantilla;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_plantilla_momentos_metodologiaExists(eva_plantilla_momentos_metodologia.IdMomento))
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

        private bool eva_plantilla_momentos_metodologiaExists(int id)
        {
            return _context.eva_plantilla_momentos_metodologia.Any(e => e.IdMomento == id);
        }
    }
}
