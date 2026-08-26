using System;
using System.Linq;
using AccesoDatos.Data;
using AccesoDatos.Models;

namespace AccesoDatos.Repositories
{
    public class EstudianteRepository : GenericRepository<Estudiante>
    {
        public Usuario? BuscarPorNombreOApellido(string busqueda)
        {
            using var context = new AplicationDbContext();
            return context.Usuario.FirstOrDefault(u =>
                u.Nombre.ToLower().Contains(busqueda.ToLower()) ||
                u.Apellido.ToLower().Contains(busqueda.ToLower()));
        }
        public double ObtenerPromedioEstudiante(int estudianteId)
        {
            using var context = new AplicationDbContext();
            var notasFinales = context.Examenes
                .Where(e => e.EstudianteId == estudianteId && e.Tipo == "Final")
                .Select(e => e.Nota)
                .ToList();

            return notasFinales.Any() ? notasFinales.Average() : 0.0;
        }

        public double ObtenerPromedioParcialesMateriaAnoActual(int materiaId)
        {
            using var context = new AplicationDbContext();
            int anoActual = DateTime.Now.Year;

            var notasParciales = context.Examenes
                .Where(e => e.MateriaId == materiaId && e.Tipo == "Parcial" && e.Fecha.Year == anoActual)
                .Select(e => e.Nota)
                .ToList();

            return notasParciales.Any() ? notasParciales.Average() : 0.0;
        }
    }
}