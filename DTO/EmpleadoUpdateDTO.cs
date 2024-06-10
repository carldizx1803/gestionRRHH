namespace gestionRRHH.DTO
{
    public class EmpleadoUpdateDTO
    {

        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int? DepartamentoId { get; set; }  // Nullable porque un empleado puede no tener departamento asignado
        public int? PuestoId { get; set; }        // Nullable porque un empleado puede no tener puesto asignado
        public decimal Salario { get; set; }

    }
}
