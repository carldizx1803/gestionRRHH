namespace gestionRRHH.DTO
{
    public class BeneficioUpdateDTO
    {
        public int? EmpleadoId { get; set; }
        public string Tipo { get; set; } = null!;
        public string? Descripcion { get; set; }

    }
}
