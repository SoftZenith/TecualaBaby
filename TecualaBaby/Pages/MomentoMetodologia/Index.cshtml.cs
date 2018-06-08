using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public IList<eva_plantilla_momentos_metodologia> eva_plantilla_momentos_metodologia { get;set; }
        
        [TempData]
        public string idplantilla { get; set; }
        [TempData]
        public string idmetodologia { get; set; }

        [TempData]
        public int idp { get; set; }
        [TempData]
        public int idm { get; set; }

        public async Task OnGetAsync(int? id)
        {

            

            eva_plantilla_momentos_metodologia = 
                await  _context.eva_plantilla_momentos_metodologia
                .Include(e => e.Metodologia)
                .Include(e => e.PlantillaMetodologia)
                .Where(x => x.IdPlantillaMetodo == id)
                .ToListAsync();

            idp = (from p in _context.eva_plantilla_metodologia
                   where p.IdPlantillaMetodo == id
                   select p.IdPlantillaMetodo).ToArray().FirstOrDefault();

            idm = (from p in _context.eva_plantilla_metodologia
                   where p.IdPlantillaMetodo == id
                   select p.Metodologia.IdMetodologia).ToArray().FirstOrDefault();

            idplantilla = (from p in _context.eva_plantilla_metodologia 
                           where p.IdPlantillaMetodo == id
                           select p.DesPlantillaMetodo).ToArray().FirstOrDefault();

            idmetodologia = (from p in _context.eva_plantilla_metodologia
                             where p.IdPlantillaMetodo == id
                             select p.Metodologia.Clave).ToArray().FirstOrDefault();
        }
    }
}
