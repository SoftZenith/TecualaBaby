using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.CompetenciaPotencias
{
    public class DetailsModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DetailsModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public CompetenciaPotencia CompetenciaPotencia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompetenciaPotencia = await _context.CompetenciaPotenciaEstatus.SingleOrDefaultAsync(m => m.persona == id);

            if (CompetenciaPotencia == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
