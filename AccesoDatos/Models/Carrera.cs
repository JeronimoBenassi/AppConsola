using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Estudiante> Estudiantes { get; set; } = new();
        public List<Materia> Materias { get; set; } = new();
    }
}
