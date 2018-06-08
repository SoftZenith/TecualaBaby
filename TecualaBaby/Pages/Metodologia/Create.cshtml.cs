﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.Metodologia
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
            return Page();
        }

        [BindProperty]
        public eva_cat_metodologias eva_cat_metodologias { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(eva_cat_metodologiasExists(eva_cat_metodologias.Clave))
            {
                Message = $"Error, duplicacion de Clave:  {eva_cat_metodologias.Clave} Ya existe";
                return Page();
            }

            _context.eva_cat_metodologias.Add(eva_cat_metodologias);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool eva_cat_metodologiasExists(string clave)
        {
            return _context.eva_cat_metodologias.Any(e => e.Clave == clave);
        }

    }
}