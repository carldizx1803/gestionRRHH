using System;
using System.Collections.Generic;

namespace gestionRRHH.Models;

public partial class Beneficio
{
    public int BeneficioId { get; set; }

    public int? EmpleadoId { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
