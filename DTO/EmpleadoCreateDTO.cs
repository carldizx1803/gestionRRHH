using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace gestionRRHH.DTO
{
    public class EmpleadoCreateDTO
    {

        //[Required(ErrorMessage = "El nombre HHHHHH.")]
        public string? Nombre { get; set; }

        //[Required(ErrorMessage = "El apellido es requerido.")]
        public string? Apellido { get; set; }

        //[Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        public DateTime FechaNacimiento { get; set; }

        //[Required(ErrorMessage = "La fecha de contratación es requerida.")]
        public DateTime FechaContratacion { get; set; }

        public int? DepartamentoId { get; set; } // Nullable porque un empleado puede no tener departamento asignado

        public int? PuestoId { get; set; } // Nullable porque un empleado puede no tener puesto asignado

        public decimal Salario { get; set; }

    }
}
