using System;
using System.Collections.Generic;

namespace gestionRRHH.Models;

public partial class Vacacion
{
    public int VacacionId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public bool Aprobada { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
