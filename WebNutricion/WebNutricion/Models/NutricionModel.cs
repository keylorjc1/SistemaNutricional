using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebNutricion.Models
{
    public partial class NutricionModel : DbContext
    {
        public NutricionModel()
            : base("name=NutricionModel")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<planAlimentacion> planAlimentacions { get; set; }
        public virtual DbSet<planificacionNutricional> planificacionNutricionals { get; set; }
        public virtual DbSet<valoresNutricionale> valoresNutricionales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.planAlimentacions)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.idUser);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.planificacionNutricionals)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.idUser);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.valoresNutricionales)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.idUser);

            modelBuilder.Entity<planificacionNutricional>()
                .Property(e => e.objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<valoresNutricionale>()
                .Property(e => e.motivo)
                .IsUnicode(false);

            modelBuilder.Entity<valoresNutricionale>()
                .Property(e => e.expectativas)
                .IsUnicode(false);

            modelBuilder.Entity<valoresNutricionale>()
                .Property(e => e.informacionConsulta)
                .IsUnicode(false);

            modelBuilder.Entity<valoresNutricionale>()
                .Property(e => e.historial)
                .IsUnicode(false);
        }
    }
}
