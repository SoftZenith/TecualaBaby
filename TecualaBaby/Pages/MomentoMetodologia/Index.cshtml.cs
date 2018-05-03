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
    public class IndexModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public IndexModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MomentosMetodologia> MomentosMetodologia { get;set; }

        public async Task OnGetAsync()
        {
            MomentosMetodologia = await _context.MomentosMetodologia
                .Include(m => m.Metodologia)
                .Include(m => m.PlantillaMetodologia).ToListAsync();
        }
    }
}
