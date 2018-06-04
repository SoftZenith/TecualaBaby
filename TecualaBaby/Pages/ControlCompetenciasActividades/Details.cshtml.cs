using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.ControlCompetenciasActividades
{
    public class DetailsModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DetailsModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public eva_control_competencias_actividades eva_control_competencias_actividades { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_control_competencias_actividades = await _context.eva_control_competencias_actividades
                .Include(e => e.ActividadesSugeridas)
                .Include(e => e.Competencia)
                .Include(e => e.CompetenciasPersona)
                .Include(e => e.Oportunidades).SingleOrDefaultAsync(m => m.IdActividad == id);

            if (eva_control_competencias_actividades == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
