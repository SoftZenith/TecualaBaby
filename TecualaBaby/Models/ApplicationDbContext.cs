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
        public DbSet<TecualaBaby.Models.MomentosMetodologia> MomentosMetodologia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Plantilla Metodologia
            modelBuilder.Entity<PlantillaMetodologia>()
                .HasOne(e => e.Metodologia)
                .WithMany(b => b.PlantillaMetodologias)
                .HasForeignKey(p => p.MetodologiaId)
                .HasConstraintName("ForeignKey_PlantillaMetodologia_Metodologia");

            //Momentos Metodologias
            modelBuilder.Entity<MomentosMetodologia>()
                .HasOne(e => e.Metodologia)
                .WithMany(b => b.MomentosMetodologias)
                .HasForeignKey(p => p.MetodologiaId)
                .HasConstraintName("ForeignKey_MomentosMetodologia_Metodologia");

            modelBuilder.Entity<MomentosMetodologia>()
                .HasOne(e => e.PlantillaMetodologia)
                .WithMany(b => b.MomentosMetodologias)
                .HasForeignKey(p => p.PlantillaMetodologiaId)
                .HasConstraintName("ForeignKey_MomentosMetodologia_PlantillaMetodologia");

        }
    
    }
}
