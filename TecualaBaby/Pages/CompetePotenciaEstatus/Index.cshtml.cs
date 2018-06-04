﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.CompetePotenciaEstatus
{
    public class IndexModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public IndexModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_compete_potencia_estatus> eva_compete_potencia_estatus { get;set; }

        public async Task OnGetAsync()
        {
            eva_compete_potencia_estatus = await _context.eva_compete_potencia_estatus
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona).ToListAsync();
        }
    }
}
