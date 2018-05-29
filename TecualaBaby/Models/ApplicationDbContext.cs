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

        public DbSet<eva_cat_metodologias> eva_cat_metodologias { get; set; }
        public DbSet<eva_plantilla_metodologia> eva_plantilla_metodologia { set; get; }
        public DbSet<eva_plantilla_momentos_metodologia> eva_plantilla_momentos_metodologia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Plantilla Metodologia
            modelBuilder.Entity<eva_plantilla_metodologia>()
                .HasOne(e => e.Metodologia)
                .WithMany(b => b.PlantillaMetodologia)
                .HasForeignKey(p => p.IdMetodologia)
                .HasConstraintName("ForeignKey_PlantillaMetodologia_Metodologia");

            //Momentos Metodologias
            modelBuilder.Entity<eva_plantilla_momentos_metodologia>()
                .HasOne(e => e.PlantillaMetodologia)
                .WithMany(b => b.MomentosMetodologias)
                .HasForeignKey(p => p.IdPlantillaMetodo)
                .HasConstraintName("ForeignKey_MomentosMetodologia_PlantillaMetodologia");

            /*modelBuilder.Entity<eva_plantilla_momentos_metodologia>()
                .HasOne(e => e.Metodologia)
                .WithMany(b => b.)
                .HasForeignKey(p => p.PlantillaMetodologiaId)
                .HasConstraintName("ForeignKey_MomentosMetodologia_PlantillaMetodologia");
              */  
        }
    
    }
}
