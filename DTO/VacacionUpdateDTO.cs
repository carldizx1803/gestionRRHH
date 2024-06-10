namespace gestionRRHH.DTO
{
    public class VacacionUpdateDTO
    {
        public int VacacionId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Aprobada { get; set; }

    }
}
