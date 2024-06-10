namespace gestionRRHH.DTO
{
    public class CapacitacionUpdateDTO
    {
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int? EmpleadoId { get; set; }

    }
}
