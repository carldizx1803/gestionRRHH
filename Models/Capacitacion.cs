using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace gestionRRHH.Models;

public partial class Capacitacion
{
    public int CapacitacionId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public int? EmpleadoId { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
