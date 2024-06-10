namespace gestionRRHH.DTO
{
    public class VacacionCreateDTO
    {
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Aprobada { get; set; }

    }
}
