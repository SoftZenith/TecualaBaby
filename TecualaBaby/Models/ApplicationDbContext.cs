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
        public DbSet<eva_compete_potencia_estatus> eva_compete_potencia_estatus { get; set; }
        public DbSet<eva_control_competencias_actividades> eva_control_competencias_actividades { get; set; }
        public DbSet<eva_evalua_competencias_persona> eva_evalua_competencias_persona { get; set; }
        public DbSet<eva_evalua_competencias_responsables> eva_evalua_competencias_responsables { get; set; }
        public DbSet<eva_evalua_conocimientos_oportunidad> eva_evalua_conocimientos_oportunidad { get; set; }
        public DbSet<eva_evalua_oportunidades> eva_evalua_oportunidades { get; set; }

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

            modelBuilder.Entity<eva_plantilla_momentos_metodologia>()
                .HasOne(e => e.Metodologia)
                .WithMany(b => b.MomentosMetodologias)
                .HasForeignKey(p => p.IdMetodologia)
                .HasConstraintName("ForeignKey_MomentosMetodologia_Metodologia");

            //Competencias Persona
            modelBuilder.Entity<eva_evalua_competencias_persona>()
              .HasOne(e => e.Competencia)
              .WithMany(b => b.CompetenciasPersonas)
              .HasForeignKey(p => p.IdCompetencia)
              .HasConstraintName("ForeignKey_CompetenciasPersona_Competencia");

            modelBuilder.Entity<eva_evalua_competencias_persona>()
              .HasOne(e => e.Competencia)
              .WithMany(b => b.CompetenciasPersonas)
              .HasForeignKey(p => p.IdTipoCompetencia)
              .HasConstraintName("ForeignKey_CompetenciasPersona_Competencia");

            //Compete Potencia Estatus
            modelBuilder.Entity<eva_compete_potencia_estatus>()
              .HasOne(e => e.Competencia)
              .WithMany(b => b.CompetePotenciaEstatus)
              .HasForeignKey(p => p.IdCompetencia)
              .HasConstraintName("ForeignKey_CompetePotenciaEstatus_Competencia");

            modelBuilder.Entity<eva_compete_potencia_estatus>()
              .HasOne(e => e.CompetenciasPersona)
              .WithMany(b => b.CompetePotenciaEstatus)
              .HasForeignKey(p => p.IdPersona)
              .HasConstraintName("ForeignKey_CompetePotenciaEstatus_CompetenciasPersona");

            //Oportunidades
            modelBuilder.Entity<eva_evalua_oportunidades>()
              .HasOne(e => e.Competencia)
              .WithMany(b => b.Oportunidades)
              .HasForeignKey(p => p.IdCompetencia)
              .HasConstraintName("ForeignKey_Oportunidades_Competencia");

            modelBuilder.Entity<eva_evalua_oportunidades>()
              .HasOne(e => e.CompetenciasPersona)
              .WithMany(b => b.Oportunidades)
              .HasForeignKey(p => p.IdPersona)
              .HasConstraintName("ForeignKey_Oportunidades_CompetenciasPersona");

            modelBuilder.Entity<eva_evalua_oportunidades>()
              .HasOne(e => e.Metodologia)
              .WithMany(b => b.Oportunidades)
              .HasForeignKey(p => p.IdMetodologia)
              .HasConstraintName("ForeignKey_Oportunidades_Metodologia");

            //CompetenciasResponsables
            modelBuilder.Entity<eva_evalua_competencias_responsables>()
              .HasOne(e => e.Competencia)
              .WithMany(b => b.CompetenciasResponsables)
              .HasForeignKey(p => p.IdCompetencia)
              .HasConstraintName("ForeignKey_CompetenciasResponsables_Competencia");

            modelBuilder.Entity <eva_evalua_competencias_responsables>()
              .HasOne(e => e.CompetenciasPersona)
              .WithMany(b => b.CompetenciasResponsables)
              .HasForeignKey(p => p.IdPersona)
              .HasConstraintName("ForeignKey_CompetenciasResponsables_CompetenciasPersona");

            modelBuilder.Entity<eva_evalua_competencias_responsables>()
              .HasOne(e => e.Oportunidades)
              .WithMany(b => b.CompetenciasResponsables)
              .HasForeignKey(p => p.IdOportunidad)
              .HasConstraintName("ForeignKey_CompetenciasResponsables_Oportunidades");

            //ConocimientosOportunidad
            modelBuilder.Entity<eva_evalua_conocimientos_oportunidad>()
              .HasOne(e => e.Competencia)
              .WithMany(b => b.ConocimientosOportunidad)
              .HasForeignKey(p => p.IdCompetencia)
              .HasConstraintName("ForeignKey_ConocimientosOportunidad_Competencia");

            modelBuilder.Entity<eva_evalua_conocimientos_oportunidad>()
              .HasOne(e => e.CompetenciasPersona)
              .WithMany(b => b.ConocimientosOportunidad)
              .HasForeignKey(p => p.IdPersona)
              .HasConstraintName("ForeignKey_ConocimientosOportunidad_CompetenciasPersona");

            modelBuilder.Entity<eva_evalua_conocimientos_oportunidad>()
             .HasOne(e => e.Competencia)
             .WithMany(b => b.ConocimientosOportunidad)
             .HasForeignKey(p => p.IdTipoCompetencia)
             .HasConstraintName("ForeignKey_ConocimientoOportunidad_Competencia");

            modelBuilder.Entity<eva_evalua_conocimientos_oportunidad>()
              .HasOne(e => e.Oportunidades)
              .WithMany(b => b.ConocimientosOportunidad)
              .HasForeignKey(p => p.IdOportunidad)
              .HasConstraintName("ForeignKey_ConocimientoOportunidad_Oportunidades");

            modelBuilder.Entity<eva_evalua_conocimientos_oportunidad>()
             .HasOne(e => e.Conocimiento)
             .WithMany(b => b.ConocimientosOportunidad)
             .HasForeignKey(p => p.IdConocimiento)
             .HasConstraintName("ForeignKey_ConocimientoOportunidad_Conocimiento");

            //Control Competencias Actividades
            modelBuilder.Entity<eva_control_competencias_actividades>()
            .HasOne(e => e.Competencia)
            .WithMany(b => b.CompetenciasActividades)
            .HasForeignKey(p => p.IdCompetencia)
            .HasConstraintName("ForeignKey_ControlCompetenciasActividades_Competencia");

            modelBuilder.Entity<eva_control_competencias_actividades>()
              .HasOne(e => e.CompetenciasPersona)
              .WithMany(b => b.CompetenciasActividades)
              .HasForeignKey(p => p.IdPersona)
              .HasConstraintName("ForeignKey_ControlCompetenciasActividades_CompetenciasPersona");

            modelBuilder.Entity<eva_control_competencias_actividades>()
              .HasOne(e => e.Oportunidades)
              .WithMany(b => b.CompetenciasActividades)
              .HasForeignKey(p => p.IdOportunidad)
              .HasConstraintName("ForeignKey_ControlCompetenciasActividades_Oportunidades");

            modelBuilder.Entity<eva_control_competencias_actividades>()
             .HasOne(e => e.Actividad)
             .WithMany(b => b.ControlCompetenciasActividades)
             .HasForeignKey(p => p.IdActividadSugerida)
             .HasConstraintName("ForeignKey_ControlCompetenciasActividades_Actividad");

            modelBuilder.Entity<eva_control_competencias_actividades>()
             .HasOne(e => e.Actividad)
             .WithMany(b => b.ControlCompetenciasActividades)
             .HasForeignKey(p => p.IdTipoActividadSug)
             .HasConstraintName("ForeignKey_ControlCompetenciasActividades_Actividad");

        }

        public DbSet<TecualaBaby.Models.actividad> actividad { get; set; }

        public DbSet<TecualaBaby.Models.competencia> competencia { get; set; }

        public DbSet<TecualaBaby.Models.conocimiento> conocimiento { get; set; }

    }
}
