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

        public IList<TecualaBaby.Models.PlantillaMetodologia> PlantillaMetodologia { get;set; }

        public async Task OnGetAsync()
        {
            PlantillaMetodologia = await _context.PlantillaMetodologias
                .Include(p => p.Metodologia).ToListAsync();
        }
    }
}
