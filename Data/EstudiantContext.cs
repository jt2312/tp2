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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institucion>()
            .HasMany(p => p.Estudiantes)
            .WithOne(p=>p.Institucion)
            .HasForeignKey(d => d.InstitucionId);

        }                
    }
}
