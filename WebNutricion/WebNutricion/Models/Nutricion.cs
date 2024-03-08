using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebNutricion.Models
{
    public partial class Nutricion : DbContext
    {
        public Nutricion()
            : base("name=Nutricion")
        {
        }

        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<datosAntropometrico> datosAntropometricos { get; set; }
        public virtual DbSet<planAlimentacion> planAlimentacions { get; set; }
        public virtual DbSet<planificacionNutricional> planificacionNutricionals { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }
        public virtual DbSet<valoresNutricionale> valoresNutricionales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<datosAntropometrico>()
                .Property(e => e.datosAnaliticos)
                .IsUnicode(false);

            modelBuilder.Entity<datosAntropometrico>()
                .Property(e => e.progreso)
                .IsUnicode(false);

            modelBuilder.Entity<datosAntropometrico>()
                .HasOptional(e => e.planificacionNutricional)
                .WithRequired(e => e.datosAntropometrico);

            modelBuilder.Entity<planAlimentacion>()
                .Property(e => e.comida)
                .IsUnicode(false);

            modelBuilder.Entity<planAlimentacion>()
                .Property(e => e.alimentos)
                .IsUnicode(false);

            modelBuilder.Entity<planificacionNutricional>()
                .Property(e => e.objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Receta>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Receta>()
                .Property(e => e.Ingredientes)
                .IsUnicode(false);

            modelBuilder.Entity<Receta>()
                .Property(e => e.PasosPreparacion)
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
