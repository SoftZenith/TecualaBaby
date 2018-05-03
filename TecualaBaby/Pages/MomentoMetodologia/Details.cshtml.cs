using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.MomentoMetodologia
{
    public class DetailsModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public DetailsModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public MomentosMetodologia MomentosMetodologia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MomentosMetodologia = await _context.MomentosMetodologia
                .Include(m => m.Metodologia)
                .Include(m => m.PlantillaMetodologia).SingleOrDefaultAsync(m => m.Id == id);

            if (MomentosMetodologia == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
