using AccesoDatos.Data;
using AccesoDatos.Models;
using AccesoDatos.Repositories;

using var context = new AplicationDbContext();
// 1. Instanciamos el repositorio.
IGenericRepository<Autor> autorRepository = new GenericRepository<Autor>();
IGenericRepository<Libro> libroRepository = new GenericRepository<Libro>();
IGenericRepository<Categoria> categoriaRepository = new GenericRepository<Categoria>();


bool continuar = true;

while (continuar)
{
    Console.WriteLine("=================================================");
    Console.WriteLine("\tGestión de Autores y Libros");
    Console.WriteLine("=================================================");
    Console.WriteLine();
    Console.WriteLine("1. Agregar autor (Alta)");
    Console.WriteLine("2. Agregar libro (Alta)");
    Console.WriteLine("3. Agregar categoria (Alta)");
    Console.WriteLine("4. Ver libros");
    Console.WriteLine("5. Ver autores");
    Console.WriteLine("6. Ver categorias");
    Console.WriteLine("7. Modificar autor (Modificacion)");
    Console.WriteLine("8. Modificar libro (Modificacion)");
    Console.WriteLine("9. Eliminar libro (Baja)");
    Console.WriteLine("10. Salir");

    Console.WriteLine();

    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine();
    Console.Clear();

    switch (opcion)
    {
        case "1":
            AltaAutor();
            break;

        case "2":
            AltaLibro();
            break;

        case "3":
            AltaCategoria();
            break;

        case "4":
            VisualizarLibros();
            break;

        case "5":
            VisualizarAutores();
            break;

        case "6":
            VisualizarCategoria();
            break;

        case "7":
            ModificarAutor();
            break;

        case "8":
            ModificarLibro();
            break;

        case "9":
            EliminarLibro();
            break;

        case "10":
            Console.WriteLine("¡Cerrando el sistema!");
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            PresioneParaContinuar();
            break;
    }
}

void AltaAutor()
{
    Console.Write("Ingrese el nombre del autor: ");
    string Nombre = Console.ReadLine();

    var nuevoAutor = new Autor
    {
        Nombre = Nombre
    };


    autorRepository.Agregar(nuevoAutor);
    Console.WriteLine("Autor agregado exitosamente.");
    PresioneParaContinuar();
}

void AltaLibro()
{
    Console.Write("Ingrese el titulo del libro: ");
    string Titulo = Console.ReadLine();

    Console.Write("Ingrese el anio del libro: ");
    string Anio = Console.ReadLine();

    Console.Write("Ingrese el id del autor: ");
    int AutorId = int.Parse(Console.ReadLine());

    Console.Write("Ingrese el id de la categoria: ");
    int CategoriaId = int.Parse(Console.ReadLine());

    var nuevoLibro = new Libro
    {
        Titulo = Titulo,
        Anio = int.Parse(Anio),
        AutorId = AutorId,
        Activo = true,
        CategoriaId = CategoriaId,
    };

    libroRepository.Agregar(nuevoLibro);
    Console.WriteLine("Libro agregado exitosamente.");
    PresioneParaContinuar();
}

void VisualizarLibros()
{
    MostrarListaLibros(libroRepository);
    PresioneParaContinuar();
}

void MostrarListaLibros(IGenericRepository<Libro> repository)
{
    Console.WriteLine("--- LISTADO ACTUAL DE LIBROS EN BASE DE DATOS ---");
    var libros = repository.ObtenerTodosCon("Autor");


    if (!libros.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var l in libros)
        {
            Console.WriteLine($"ID: {l.Id} | Año: {l.Anio} | Título: {l.Titulo} | Autor: {l.Autor.Nombre}");
        }
    }
    Console.WriteLine("---------------------------------------");
    Console.WriteLine();
}
void AltaCategoria()
{
    Console.Write("Ingrese el nombre de la categoria: ");
    string Nombre = Console.ReadLine();

    var nuevaCategoria = new Categoria
    {
        Nombre = Nombre
    };


    categoriaRepository.Agregar(nuevaCategoria);
    Console.WriteLine("Categoria agregada exitosamente.");
    PresioneParaContinuar();
}
void VisualizarAutores()
{
    MostrarListaAutores(autorRepository);
    PresioneParaContinuar();
}
void MostrarListaAutores(IGenericRepository<Autor> repository)
{
    Console.WriteLine("--- LISTADO ACTUAL DE AUTORES EN BASE DE DATOS ---");
    var autores = repository.ObtenerTodos();

    if (!autores.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var a in autores)
        {
            Console.WriteLine($"ID: {a.AutorId} | Nombre: {a.Nombre}");
        }
    }
    Console.WriteLine("---------------------------------------");
    Console.WriteLine();
}

void VisualizarCategoria()
{
    MostrarListaCategorias(categoriaRepository);
    PresioneParaContinuar();
}
void MostrarListaCategorias(IGenericRepository<Categoria> repository)
{
    Console.WriteLine("--- LISTADO ACTUAL DE CATEGORIAS EN BASE DE DATOS ---");
    var categorias = repository.ObtenerTodos();

    if (!categorias.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var c in categorias)
        {
            Console.WriteLine($"ID: {c.Id} | Nombre: {c.Nombre}");
        }
    }
    Console.WriteLine("---------------------------------------");
    Console.WriteLine();
}
void ModificarLibro()
{
    Console.Write("Ingrese el ID del libro a modificar: ");
    int libroId = int.Parse(Console.ReadLine());
    var libroExistente = libroRepository.ObtenerPorId(libroId);
    if (libroExistente == null)

    {
        Console.WriteLine("No se encontró un libro con ese ID.");
        PresioneParaContinuar();
        return;
    }

    Console.Write("Ingrese el nuevo título del libro: ");
    string nuevoTitulo = Console.ReadLine();

    Console.Write("Ingrese el nuevo año del libro: ");
    int nuevoAnio = int.Parse(Console.ReadLine());

    Console.Write("Ingrese el nuevo ID del autor: ");
    int nuevoAutorId = int.Parse(Console.ReadLine());

    Console.Write("Ingrese el nuevo ID de la categoría: ");
    int nuevaCategoriaId = int.Parse(Console.ReadLine());

    libroExistente.Titulo = nuevoTitulo;
    libroExistente.Anio = nuevoAnio;
    libroExistente.AutorId = nuevoAutorId;
    libroExistente.CategoriaId = nuevaCategoriaId;
    libroRepository.Modificar(libroExistente);

    Console.WriteLine("Libro modificado exitosamente.");
    PresioneParaContinuar();
}

void ModificarAutor()
{
    Console.Write("Ingrese el ID del autor a modificar: ");
    int autorId = int.Parse(Console.ReadLine());

    var autorExistente = autorRepository.ObtenerPorId(autorId);
    if (autorExistente == null)

    {
        Console.WriteLine("No se encontró un autor con ese ID.");
        PresioneParaContinuar();
        return;
    }
    Console.Write("Ingrese el nuevo nombre del autor: ");
    string nuevoNombre = Console.ReadLine();

    autorExistente.Nombre = nuevoNombre;
    autorRepository.Modificar(autorExistente);

    Console.WriteLine("Autor modificado exitosamente.");
    PresioneParaContinuar();
}
void EliminarLibro()
{
    Console.Write("Ingrese el ID del libro a cambiar el estado: ");
    int libroId = int.Parse(Console.ReadLine());
    var libroExistente = libroRepository.ObtenerPorId(libroId);

    if (libroExistente == null)
    {
        Console.WriteLine("No se encontró un libro con ese ID.");
        PresioneParaContinuar();
        return;
    }

    libroExistente.Activo = false;

    libroRepository.Modificar(libroExistente);

    Console.WriteLine("Libro eliminado exitosamente.");
    PresioneParaContinuar();
}

void PresioneParaContinuar()
{
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}
