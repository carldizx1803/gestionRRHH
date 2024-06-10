using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gestionRRHH.Models;

public partial class RecursosHumanosContext : DbContext
{
    public RecursosHumanosContext()
    {
    }

    public RecursosHumanosContext(DbContextOptions<RecursosHumanosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beneficio> Beneficios { get; set; }

    public virtual DbSet<Capacitacion> Capacitacions { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Evaluacion> Evaluacions { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Vacacion> Vacacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=CARLOSPC;Database=RecursosHumanos;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beneficio>(entity =>
        {
            entity.HasKey(e => e.BeneficioId).HasName("PK__Benefici__A02B32B18B240649");

            entity.ToTable("Beneficio");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Tipo).HasMaxLength(100);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Beneficios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Beneficio__Emple__35BCFE0A");
        });

        modelBuilder.Entity<Capacitacion>(entity =>
        {
            entity.HasKey(e => e.CapacitacionId).HasName("PK__Capacita__42816922965D490F");

            entity.ToTable("Capacitacion");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Capacitacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Capacitac__Emple__32E0915F");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DepartamentoId).HasName("PK__Departam__66BB0E3EF27AA967");

            entity.ToTable("Departamento");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE9103E09E31C");

            entity.ToTable("Empleado");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__Empleado__Depart__29572725");

            entity.HasOne(d => d.Puesto).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.PuestoId)
                .HasConstraintName("FK__Empleado__Puesto__2A4B4B5E");
        });

        modelBuilder.Entity<Evaluacion>(entity =>
        {
            entity.HasKey(e => e.EvaluacionId).HasName("PK__Evaluaci__99ABA7454EB78018");

            entity.ToTable("Evaluacion");

            entity.Property(e => e.Comentarios).HasMaxLength(500);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Evaluacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Evaluacio__Emple__300424B4");
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.NominaId).HasName("PK__Nomina__33A376122DA9A9E1");

            entity.ToTable("Nomina");

            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Nomina__Empleado__2D27B809");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.PuestoId).HasName("PK__Puesto__F7F6C6045A3DA114");

            entity.ToTable("Puesto");

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Departamento).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__Puesto__Departam__267ABA7A");
        });

        modelBuilder.Entity<Vacacion>(entity =>
        {
            entity.HasKey(e => e.VacacionId).HasName("PK__Vacacion__CEAEE9DA3ADEFC49");

            entity.ToTable("Vacacion");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Vacacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Vacacion__Emplea__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
