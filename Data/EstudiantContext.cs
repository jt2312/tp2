using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tp2.Models;


namespace Tp2.Data
{
    public class EstudiantContext : DbContext
    {
        public EstudiantContext (DbContextOptions<EstudiantContext> options)
            : base(options)
        {
        }

        public DbSet<Tp2.Models.Estudiante> Estudiante { get; set; } = default!;

        public DbSet<Tp2.Models.Institucion> Institucion { get; set; } = default!;

        public DbSet<Tp2.Models.Direccion> Direccion { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institucion>()
            .HasMany(p=> p.Estudiantes)
            .WithOne()
            .HasForeignKey(p => p.InstitucionId);


            modelBuilder.Entity<Direccion>()
            .HasOne(p=> p.Estudiante)
            .WithOne(p => p.Direccion)
            .HasForeignKey(p => p.DireccionId);

            modelBuilder.Entity<Estudiante>()
            .HasMany(p=> p.)
            .WithMany(p => p.)
            .HasForeignKey(p => p.);        

        }
           
    }
}
