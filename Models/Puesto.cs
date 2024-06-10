using System;
using System.Collections.Generic;

namespace gestionRRHH.Models;

public partial class Puesto
{
    public int PuestoId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? DepartamentoId { get; set; }

    public virtual Departamento? Departamento { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
