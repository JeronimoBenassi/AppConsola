using AccesoDatos.Data;
using AccesoDatos.Models;
using AccesoDatos.Repositories;


IGenericRepository<Estudiante> estudianteRepo = new GenericRepository<Estudiante>();
IGenericRepository<Profesor> profesorRepo = new GenericRepository<Profesor>();

bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("=================================================");
    Console.WriteLine("\tGestión de Usuarios");
    Console.WriteLine("=================================================");
    Console.WriteLine();
    Console.WriteLine("1. Agregar usuario (Alta)");
    Console.WriteLine("2. Modificar usuario (Modificación)");
    Console.WriteLine("3. Eliminar usuario (Baja)");
    Console.WriteLine("4. Ver todos los usuarios");
    Console.WriteLine("5. Salir");
    Console.WriteLine();

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
            Console.WriteLine("¡Cerrando el sistema de usuarios!");
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            PresioneParaContinuar();
            break;
    }
}

void PresioneParaContinuar()
{
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}

void AltaUsuario()
{
    Console.Clear();
    Console.WriteLine("--- ALTA DE USUARIO ---");
    Console.WriteLine("1. Estudiante");
    Console.WriteLine("2. Profesor");
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        var e = new Estudiante();
        Console.Write("Nombre: "); e.Nombre = Console.ReadLine();
        Console.Write("Apellido: "); e.Apellido = Console.ReadLine();
        Console.Write("Legajo: "); e.Legajo = Console.ReadLine();
        Console.Write("Promedio: "); e.Promedio = double.Parse(Console.ReadLine());

        estudianteRepo.Agregar(e);
        Console.WriteLine("\n¡Estudiante guardado con éxito!");
    }
    else if (opcion == "2")
    {
        var p = new Profesor();
        Console.Write("Nombre: "); p.Nombre = Console.ReadLine();
        Console.Write("Apellido: "); p.Apellido = Console.ReadLine();
        Console.Write("Especialidad: "); p.Especialidad = Console.ReadLine();
        Console.Write("Sueldo: "); p.Sueldo = decimal.Parse(Console.ReadLine());

        profesorRepo.Agregar(p);
        Console.WriteLine("\n¡Profesor guardado con éxito!");
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }

    PresioneParaContinuar();
}

void ModificarUsuario()
{
    Console.Clear();
    Console.WriteLine("--- MODIFICAR USUARIO ---");
    Console.WriteLine("1. Modificar Estudiante");
    Console.WriteLine("2. Modificar Profesor");
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        Console.Write("Ingrese el ID del estudiante a modificar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var e = estudianteRepo.ObtenerPorId(id);
            if (e != null)
            {
                Console.Write($"Nuevo Nombre ({e.Nombre}): "); e.Nombre = Console.ReadLine();
                Console.Write($"Nuevo Apellido ({e.Apellido}): "); e.Apellido = Console.ReadLine();
                Console.Write($"Nuevo Legajo ({e.Legajo}): "); e.Legajo = Console.ReadLine();
                Console.Write($"Nuevo Promedio ({e.Promedio}): "); e.Promedio = double.Parse(Console.ReadLine());

                estudianteRepo.Modificar(e);
                Console.WriteLine("Estudiante actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró ningún estudiante con ese ID.");
            }
        }
    }
    else if (opcion == "2")
    {
        Console.Write("Ingrese el ID del profesor a modificar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var p = profesorRepo.ObtenerPorId(id);
            if (p != null)
            {
                Console.Write($"Nuevo Nombre ({p.Nombre}): "); p.Nombre = Console.ReadLine();
                Console.Write($"Nuevo Apellido ({p.Apellido}): "); p.Apellido = Console.ReadLine();
                Console.Write($"Nueva Especialidad ({p.Especialidad}): "); p.Especialidad = Console.ReadLine();
                Console.Write($"Nuevo Sueldo ({p.Sueldo}): "); p.Sueldo = decimal.Parse(Console.ReadLine());

                profesorRepo.Modificar(p);
                Console.WriteLine("Profesor actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró ningún profesor con ese ID.");
            }
        }
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }

    PresioneParaContinuar();
}

void BajaUsuario()
{
    Console.Clear();
    Console.WriteLine("--- ELIMINAR USUARIO ---");
    Console.WriteLine("1. Eliminar Estudiante");
    Console.WriteLine("2. Eliminar Profesor");
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        Console.Write("Ingrese el ID del estudiante a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            estudianteRepo.Eliminar(id);
            Console.WriteLine("Proceso de eliminación de estudiante finalizado.");
        }
    }
    else if (opcion == "2")
    {
        Console.Write("Ingrese el ID del profesor a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            profesorRepo.Eliminar(id);
            Console.WriteLine("Proceso de eliminación de profesor finalizado.");
        }
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }

    PresioneParaContinuar();
}

void VisualizarUsuarios()
{
    Console.Clear();
    Console.WriteLine("--- LISTA DE USUARIOS ---");
    Console.WriteLine("1. Ver Estudiantes");
    Console.WriteLine("2. Ver Profesores");
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        var estudiantes = estudianteRepo.ObtenerTodos();
        Console.WriteLine("\n--- ESTUDIANTES ---");
        foreach (var e in estudiantes)
        {
            Console.WriteLine($"ID: {e.Id} | Nombre: {e.Nombre} {e.Apellido} | Legajo: {e.Legajo} | Promedio: {e.Promedio}");
        }
    }
    else if (opcion == "2")
    {
        var profesores = profesorRepo.ObtenerTodos();
        Console.WriteLine("\n--- PROFESORES ---");
        foreach (var p in profesores)
        {
            Console.WriteLine($"ID: {p.Id} | Nombre: {p.Nombre} {p.Apellido} | Especialidad: {p.Especialidad} | Sueldo: ${p.Sueldo}");
        }
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }

    PresioneParaContinuar();
}