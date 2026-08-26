using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{ 
public class Materia
    {
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int CarreraId { get; set; }
    public Carrera Carrera { get; set; }
    public List<Examen> Examenes { get; set; } = new();
    
    }
}
