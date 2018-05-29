using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TecualaBaby.Models;

namespace TecualaBaby.Pages.Metodologia
{
    public class IndexModel : PageModel
    {
        private readonly TecualaBaby.Models.ApplicationDbContext _context;

        public IndexModel(TecualaBaby.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<eva_cat_metodologias> eva_cat_metodologias { get;set; }

        public async Task OnGetAsync()
        {
            eva_cat_metodologias = await _context.eva_cat_metodologias.ToListAsync();
        }
    }
}
