﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace gestionRRHH.DTO
{
    public class PuestoUpdateDTO
    {
        public string Nombre { get; set; }
        public int? DepartamentoId { get; set; }
    }
}