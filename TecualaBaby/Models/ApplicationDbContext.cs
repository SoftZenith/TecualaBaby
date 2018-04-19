using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecualaBaby.Models;

namespace TecualaBaby.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Metodologia> Metodologias { get; set; }
        public DbSet<PlantillaMetodologia> PlantillaMetodologias { set; get; }
        public DbSet<TecualaBaby.Models.CompetenciaPotencia> CompetenciaPotenciaEstatus { get; set; }
        public DbSet<TecualaBaby.Models.MomentosMetodologias> MomentosMetodologias { get; set; }
    }
}
