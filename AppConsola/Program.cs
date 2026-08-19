using AccesoDatos.Models;
using AccesoDatos.Repositories;

IGenericRepository<Estudiante> estudianteRepository = new GenericRepository<Estudiante>();
IGenericRepository<Profesor> profesorRepository = new GenericRepository<Profesor>();
IGenericRepository<Carrera> carreraRepository = new GenericRepository<Carrera>();
IGenericRepository<Materia> materiaRepository = new GenericRepository<Materia>();
IGenericRepository<Examen> examenRepository = new GenericRepository<Examen>();
IGenericRepository<MateriaAprobada> materiaAprobadaRepository = new GenericRepository<MateriaAprobada>();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("1. Alta de Usuario");
    Console.WriteLine("2. Modificar Usuario");
    Console.WriteLine("3. Eliminar Usuario");
    Console.WriteLine("4. Ver Usuarios");
    Console.WriteLine("5. Buscar Usuario");
    Console.WriteLine("6. Registrar Materia Aprobada");
    Console.WriteLine("7. Registrar Examen");
    Console.WriteLine("8. Promedio de Finales");
    Console.WriteLine("9. Promedio de Materia");
    Console.WriteLine("10. Alta Carrera");
    Console.WriteLine("11. Alta Materia");
    Console.WriteLine("0. Salir");

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    Console.Clear();

    switch (opcion)
    {
        case "1":
            AltaUsuario();
            break;

        case "2":
            ModificarUsuario();
            break;

        case "3":
            BajaUsuario();
            break;

        case "4":
            VisualizarUsuarios();
            break;

        case "5":
            BuscarUsuario();
            break;

        case "6":
            RegistrarMateriaAprobada();
            break;

        case "7":
            RegistrarExamen();
            break;

        case "8":
            ObtenerPromedioFinales();
            break;

        case "9":
            ObtenerPromedioMateria();
            break;

        case "10":
            AltaCarrera();
            break;

        case "11":
            AltaMateria();
            break;

        case "0":
            Console.WriteLine("¡Cerrando el sistema!");
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            PresioneParaContinuar();
            break;
    }
}

void AltaUsuario()
{
    Console.WriteLine("¿Qué desea agregar?");
    Console.WriteLine("1. Estudiante");
    Console.WriteLine("2. Profesor");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            AltaEstudiante();
            break;

        case "2":
            AltaProfesor();
            break;

        default:
            Console.WriteLine("Opción inválida.");
            PresioneParaContinuar();
            break;
    }
}

void AltaEstudiante()
{
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Apellido: ");
    string apellido = Console.ReadLine();

    Console.Write("Legajo: ");
    string legajo = Console.ReadLine();

    Console.WriteLine("Carreras disponibles:");

    foreach (var carrera in carreraRepository.ObtenerTodos())
    {
        Console.WriteLine($"ID: {carrera.Id} - {carrera.Nombre}");
    }

    Console.Write("Carrera ID: ");
    int carreraId = int.Parse(Console.ReadLine());

    var estudiante = new Estudiante
    {
        Name = nombre,
        LastName = apellido,
        Legajo = legajo,
        CarreraId = carreraId
    };

    estudianteRepository.Agregar(estudiante);

    Console.WriteLine("Estudiante agregado.");
    PresioneParaContinuar();
}

void AltaProfesor()
{
    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Apellido: ");
    string apellido = Console.ReadLine();

    Console.Write("Especialidad: ");
    string especialidad = Console.ReadLine();

    Console.Write("Sueldo: ");
    decimal sueldo = decimal.Parse(Console.ReadLine());

    var profesor = new Profesor
    {
        Name = nombre,
        LastName = apellido,
        Especialidad = especialidad,
        Sueldo = sueldo
    };

    profesorRepository.Agregar(profesor);

    Console.WriteLine("Profesor agregado correctamente.");
    PresioneParaContinuar();
}

void ModificarUsuario()
{
    Console.WriteLine("¿Qué desea modificar?");
    Console.WriteLine("1. Estudiante");
    Console.WriteLine("2. Profesor");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":

            MostrarEstudiantes();

            Console.Write("Ingrese el ID del estudiante: ");

            if (int.TryParse(Console.ReadLine(), out int idEstudiante))
            {
                var estudiante = estudianteRepository.ObtenerPorId(idEstudiante);

                if (estudiante != null)
                {
                    Console.Write("Nuevo nombre: ");
                    estudiante.Name = Console.ReadLine();

                    Console.Write("Nuevo apellido: ");
                    estudiante.LastName = Console.ReadLine();

                    Console.Write("Nuevo legajo: ");
                    estudiante.Legajo = Console.ReadLine();

                    Console.Write("Nuevo promedio: ");
                    estudiante.Promedio = decimal.Parse(Console.ReadLine());

                    estudianteRepository.Modificar(estudiante);

                    Console.WriteLine("Estudiante actualizado correctamente.");
                }
            }

            break;

        case "2":

            MostrarProfesores();

            Console.Write("Ingrese el ID del profesor: ");

            if (int.TryParse(Console.ReadLine(), out int idProfesor))
            {
                var profesor = profesorRepository.ObtenerPorId(idProfesor);

                if (profesor != null)
                {
                    Console.Write("Nuevo nombre: ");
                    profesor.Name = Console.ReadLine();

                    Console.Write("Nuevo apellido: ");
                    profesor.LastName = Console.ReadLine();

                    Console.Write("Nueva especialidad: ");
                    profesor.Especialidad = Console.ReadLine();

                    Console.Write("Nuevo sueldo: ");
                    profesor.Sueldo = decimal.Parse(Console.ReadLine());

                    profesorRepository.Modificar(profesor);

                    Console.WriteLine("Profesor actualizado correctamente.");
                }
            }

            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

    PresioneParaContinuar();
}

void BajaUsuario()
{
    Console.WriteLine("¿Qué desea eliminar?");
    Console.WriteLine("1. Estudiante");
    Console.WriteLine("2. Profesor");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":

            MostrarEstudiantes();

            Console.Write("Ingrese el ID del estudiante a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int idEstudiante))
            {
                estudianteRepository.Eliminar(idEstudiante);
                Console.WriteLine("Estudiante eliminado correctamente.");
            }

            break;

        case "2":

            MostrarProfesores();

            Console.Write("Ingrese el ID del profesor a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int idProfesor))
            {
                profesorRepository.Eliminar(idProfesor);
                Console.WriteLine("Profesor eliminado correctamente.");
            }

            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

    PresioneParaContinuar();
}

void VisualizarUsuarios()
{
    Console.WriteLine("¿Qué desea visualizar?");
    Console.WriteLine("1. Estudiantes");
    Console.WriteLine("2. Profesores");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            MostrarEstudiantes();
            break;

        case "2":
            MostrarProfesores();
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

    PresioneParaContinuar();
}

void MostrarEstudiantes()
{
    Console.WriteLine("----- LISTADO DE ESTUDIANTES -----");

    var estudiantes = estudianteRepository.ObtenerTodos();

    if (!estudiantes.Any())
    {
        Console.WriteLine("[No hay estudiantes registrados]");
    }
    else
    {
        foreach (var e in estudiantes)
        {
            Console.WriteLine($"ID: {e.Id} | Nombre: {e.Name} {e.LastName} | Legajo: {e.Legajo} | CarreraId: {e.CarreraId}");
        }
    }

    Console.WriteLine("---------------------------------");
}

void MostrarProfesores()
{
    Console.WriteLine("----- LISTADO DE PROFESORES -----");

    var profesores = profesorRepository.ObtenerTodos();

    if (!profesores.Any())
    {
        Console.WriteLine("[No hay profesores registrados]");
    }
    else
    {
        foreach (var p in profesores)
        {
            Console.WriteLine(
                $"ID: {p.Id} | Nombre: {p.Name} {p.LastName} | Especialidad: {p.Especialidad} | Sueldo: {p.Sueldo}");
        }
    }

    Console.WriteLine("--------------------------------");
}

void BuscarUsuario()
{
    Console.WriteLine("1. Estudiante");
    Console.WriteLine("2. Profesor");

    string tipo = Console.ReadLine();

    Console.Write("Ingrese nombre o apellido: ");
    string texto = Console.ReadLine();

    if (tipo == "1")
    {
        var resultados = estudianteRepository.Buscar(
            x => x.Name.Contains(texto)
              || x.LastName.Contains(texto));

        if (!resultados.Any())
        {
            Console.WriteLine("No encontrado. ¿Desea crearlo? (S/N)");

            if (Console.ReadLine()?.ToUpper() == "S")
            {
                AltaEstudiante();
                return;
            }
        }

        foreach (var e in resultados)
        {
            Console.WriteLine(
                $"ID:{e.Id} - {e.Name} {e.LastName}");
        }
    }
    else
    {
        var resultados = profesorRepository.Buscar(
            x => x.Name.Contains(texto)
              || x.LastName.Contains(texto));

        if (!resultados.Any())
        {
            Console.WriteLine("No encontrado. ¿Desea crearlo? (S/N)");

            if (Console.ReadLine()?.ToUpper() == "S")
            {
                AltaProfesor();
                return;
            }
        }

        foreach (var p in resultados)
        {
            Console.WriteLine(
                $"ID:{p.Id} - {p.Name} {p.LastName}");
        }
    }

    PresioneParaContinuar();
}

void RegistrarMateriaAprobada()
{
    MostrarEstudiantes();

    Console.Write("ID Estudiante: ");
    int estudianteId = int.Parse(Console.ReadLine());

    Console.Write("ID Materia: ");
    int materiaId = int.Parse(Console.ReadLine());

    var aprobada = new MateriaAprobada
    {
        EstudianteId = estudianteId,
        MateriaId = materiaId
    };

    materiaAprobadaRepository.Agregar(aprobada);

    Console.WriteLine("Materia aprobada registrada.");

    PresioneParaContinuar();
}

void RegistrarExamen()
{
    Console.Write("ID Estudiante: ");
    int estudianteId = int.Parse(Console.ReadLine());

    Console.Write("ID Materia: ");
    int materiaId = int.Parse(Console.ReadLine());

    Console.Write("Tipo (Parcial/Final): ");
    string tipo = Console.ReadLine();

    Console.Write("Nota: ");
    decimal nota = decimal.Parse(Console.ReadLine());

    Console.Write("Fecha (dd/MM/yyyy): ");
    DateTime fecha = DateTime.Parse(Console.ReadLine());    

        var examen = new Examen
    {
        Fecha = fecha,
        Nota = nota,
        Tipo = tipo,
        EstudianteId = estudianteId,
        MateriaId = materiaId
    };

    examenRepository.Agregar(examen);

    Console.WriteLine("Examen registrado.");

    PresioneParaContinuar();
}

void ObtenerPromedioFinales()
{
    Console.Write("ID Estudiante: ");

    int estudianteId = int.Parse(Console.ReadLine());

    var examenes = examenRepository.ObtenerTodos()
        .Where(x =>
            x.EstudianteId == estudianteId &&
            x.Tipo.ToUpper() == "FINAL")
        .ToList();

    if (!examenes.Any())
    {
        Console.WriteLine("No posee finales.");
    }
    else
    {
        var promedio = examenes.Average(x => x.Nota);

        Console.WriteLine(
            $"Promedio Finales: {promedio:F2}");
    }

    PresioneParaContinuar();
}

void ObtenerPromedioMateria()
{
    Console.Write("ID Materia: ");

    int materiaId = int.Parse(Console.ReadLine());

    int anioActual = DateTime.Now.Year;

    var examenes = examenRepository.ObtenerTodos()
        .Where(x =>
            x.MateriaId == materiaId &&
            x.Tipo.ToUpper() == "PARCIAL" &&
            x.Fecha.Year == anioActual)
        .ToList();


    if (!examenes.Any())
    {
        Console.WriteLine("No existen exámenes.");
    }
    else
    {
        var promedio = examenes.Average(x => x.Nota);

        Console.WriteLine(
            $"Promedio materia: {promedio:F2}");
    }

    PresioneParaContinuar();
}

void AltaCarrera()
{
    Console.Write("Nombre carrera: ");

    var carrera = new Carrera
    {
        Nombre = Console.ReadLine()
    };

    carreraRepository.Agregar(carrera);

    Console.WriteLine("Carrera agregada.");

    PresioneParaContinuar();
}

void AltaMateria()
{
    Console.Write("Nombre materia: ");

    var materia = new Materia
    {
        Nombre = Console.ReadLine()
    };

    materiaRepository.Agregar(materia);

    Console.WriteLine("Materia agregada.");

    PresioneParaContinuar();
}

void PresioneParaContinuar()
{
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}