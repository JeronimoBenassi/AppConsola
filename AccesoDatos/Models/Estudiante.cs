using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class Estudiante : Usuario
    {
        public string Legajo { get; set; } 
        public double Promedio { get; set; }
        public int? CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        public List<Examen> Examenes { get; set; } = new();
        public List<EstudianteMateriaAprobada> MateriasAprobadas { get; set; } = new();
    }
}