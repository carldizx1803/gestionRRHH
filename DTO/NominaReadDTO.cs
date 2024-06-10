namespace gestionRRHH.DTO
{
    public class NominaReadDTO
    {
        public int NominaId { get; set; }

        public int? EmpleadoId { get; set; }

        public DateTime FechaPago { get; set; }

        public decimal Monto { get; set; }

    }
}
