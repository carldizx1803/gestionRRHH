using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace gestionRRHH.DTO
{
    public class EvaluacionUpdateDTO
    {

        public DateTime Fecha { get; set; }
        public int Puntuacion { get; set; }
        public string Comentarios { get; set; }
        public int? EmpleadoId { get; set; }


    }
}
