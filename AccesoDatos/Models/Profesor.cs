using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Profesor : Usuario
    {
        public string Especialidad { get; set; } = string.Empty;
        public decimal Sueldo { get; set; }
    }
}
