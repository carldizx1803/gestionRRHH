using gestionRRHH.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace gestionRRHH.dbContext
{
    public class ApplicationDbContext : DbContext

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Beneficio> Beneficio { get; set; }
        public DbSet<Capacitacion> Capacitacion { get; set; }
        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<Nomina> Nomina { get; set; }
        public DbSet<Vacacion> Vacacion { get; set; }


    }
}
