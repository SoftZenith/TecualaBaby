﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.EvaluaCompetenciasPersona
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
            
            ViewData["IdGenOrigenCompe"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem{ Text="Asignatura Curricular", Value = "1"},
                new SelectListItem{ Text="Extraordinarias", Value="2"},
                new SelectListItem{ Text="ExtraCurricular", Value="3" }
            },"Value","Text");

            ViewData["IdCompetencia"] = new SelectList(_context.eva_cat_competencias, "IdCompetencia", "DesCompetencia");

        ViewData["IdTipoCompetencia"] = new SelectList(_context.eva_cat_tipo_competencias, "IdTipoCompetencia", "DesTipoCompetencia");
            return Page();
            
        }

    [BindProperty]
        public eva_evalua_competencias_persona eva_evalua_competencias_persona { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               return Page();
            }

            if(eva_evalua_competencias_persona.FechaLimite < DateTime.Now)
            {
                return Page();
            }

            eva_evalua_competencias_persona.IdTipoGenOrigenCompe = 19;
            eva_evalua_competencias_persona.FechaReg = DateTime.Now;

            _context.eva_evalua_competencias_persona.Add(eva_evalua_competencias_persona);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        /*public JsonResult GetStates(int id)
        {
            //List<SelectListItem> states= new List<SelectListItem>();

          var lista  =  (from p in _context.eva_cat_competencias
             where p.IdTipoCompetencia == id
             select p.DesCompetencia).ToList();


            return Json(new SelectList(lista, "IdCompetencia", "DesCompetencia"));
        }*/
    }
}