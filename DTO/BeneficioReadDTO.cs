namespace gestionRRHH.DTO
{
    public class BeneficioReadDTO
    {
        public int BeneficioId { get; set; }
        public int? EmpleadoId { get; set; }
        public string Tipo { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
