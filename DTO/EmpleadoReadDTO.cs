using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace gestionRRHH.DTO
{
    public class EmpleadoReadDTO
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int? DepartamentoId { get; set; }
        public int? PuestoId { get; set; }
        public decimal Salario { get; set; }

        // Propiedades relacionadas simplificadas para este ejemplo
        // public DepartamentoDTO Departamento { get; set; }
        // public PuestoDTO Puesto { get; set; }

    }
}
