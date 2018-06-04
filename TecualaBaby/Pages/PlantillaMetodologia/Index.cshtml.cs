using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.PlantillaMetodologia
{
    public class IndexModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public IndexModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_plantilla_metodologia> eva_plantilla_metodologia { get;set; }

        public async Task OnGetAsync()
        {
            eva_plantilla_metodologia = await _context.eva_plantilla_metodologia.OrderByDescending(x => x.VersionActual)
                .Include(e => e.Metodologia).ToListAsync();
        }
    }
}
