using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace gestionRRHH.Models;

public partial class Evaluacion
{
    public int EvaluacionId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime Fecha { get; set; }

    public int Puntuacion { get; set; }

    public string? Comentarios { get; set; }

    public virtual Empleado? Empleado { get; set; }
}
