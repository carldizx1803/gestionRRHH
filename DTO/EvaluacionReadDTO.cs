using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace gestionRRHH.DTO
{
    public class EvaluacionReadDTO
    {
        public int EvaluacionId { get; set; }
        public int EmpleadoId { get; set; }
        public string EmpleadoNombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Puntuacion { get; set; }
        public string Comentarios { get; set; }

    }
}
