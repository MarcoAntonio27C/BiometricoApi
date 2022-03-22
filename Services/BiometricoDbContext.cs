using BiometricoApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiometricoApi.Services
{
    public class BiometricoDbContext : DbContext
    {
        public BiometricoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asistencia>()
                .HasOne<Empleado>()
                .WithMany()
                .HasForeignKey(x => x.EmpleadoId);
        }
    }
}
