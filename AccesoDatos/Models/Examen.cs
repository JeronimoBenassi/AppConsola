using AccesoDatos.Models;

namespace AccesoDatos.Models
{
    public class Examen
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Nota { get; set; }

        public string Tipo { get; set; }

        public int EstudianteId { get; set; }

        public Estudiante Estudiante { get; set; }

        public int MateriaId { get; set; }

        public Materia Materia { get; set; }
    }
}
