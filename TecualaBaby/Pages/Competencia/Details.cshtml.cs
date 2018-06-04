using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.Competencia
{
    public class DetailsModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DetailsModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public competencia competencia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            competencia = await _context.competencia.SingleOrDefaultAsync(m => m.IdCompetencia == id);

            if (competencia == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
