using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace gestionRRHH.DTO
{
    public class PuestoReadDTO
    {
        public int PuestoId { get; set; }
        public string? Nombre { get; set; }
        public int? DepartamentoId { get; set; }

    }
}
