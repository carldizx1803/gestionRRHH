using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace gestionRRHH.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; } = null!;

    public string? Apellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaContratacion { get; set; }

    public int? DepartamentoId { get; set; }

    public int? PuestoId { get; set; }

    public decimal Salario { get; set; }

    public virtual ICollection<Beneficio> Beneficios { get; set; } = new List<Beneficio>();

    public virtual ICollection<Capacitacion> Capacitacions { get; set; } = new List<Capacitacion>();

    public virtual Departamento? Departamento { get; set; }

    public virtual ICollection<Evaluacion> Evaluacions { get; set; } = new List<Evaluacion>();

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual Puesto? Puesto { get; set; }

    public virtual ICollection<Vacacion> Vacacions { get; set; } = new List<Vacacion>();
}
