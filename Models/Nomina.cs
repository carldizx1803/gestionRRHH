using System;
using System.Collections.Generic;

namespace gestionRRHH.Models;

public partial class Nomina
{
    public int NominaId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime FechaPago { get; set; }

    public decimal Monto { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
