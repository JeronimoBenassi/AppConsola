using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{ 
public class Examen
    {
    public int Id { get; set; }
    public string Tipo { get; set; }
    public DateTime Fecha { get; set; }
    public double Nota { get; set; }

    public int EstudianteId { get; set; }
    public Estudiante Estudiante { get; set; }

    public int MateriaId { get; set; }
    public Materia Materia { get; set; }
    }
}