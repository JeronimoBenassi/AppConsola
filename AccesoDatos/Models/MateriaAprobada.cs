using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{ 
public class EstudianteMateriaAprobada
    {
    public int EstudianteId { get; set; }
    public Estudiante Estudiante { get; set; }

    public int MateriaId { get; set; }
    public Materia Materia { get; set; }

    public DateTime FechaAprobacion { get; set; }
    }
}
