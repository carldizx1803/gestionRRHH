namespace gestionRRHH.DTO
{
    public class BeneficioCreateDTO
    {

        public int? EmpleadoId { get; set; }
        public string Tipo { get; set; } = null!;
        public string? Descripcion { get; set; }

    }
}
