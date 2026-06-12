using DataAccess.CRUD;
using DataAccess.DAO;
using Entities_DTOs;
using Newtonsoft.Json;

namespace ConsoleApp_Test.Menus;

public static class MovieMenu
{
    public static void Menu()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();

            Console.WriteLine("=== MOVIES ===");
            Console.WriteLine("1. Crear Película");
            Console.WriteLine("2. Actualizar Película");
            Console.WriteLine("3. Eliminar Película");
            Console.WriteLine("4. Consultar Una Película");
            Console.WriteLine("5. Consultar todas las Películas");
            Console.WriteLine("6. Volver");
            Console.Write("\nSeleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CreateMovie();
                    break;

                case "2":
                    UpdateMovie();
                    break;

                case "3":
                    DeleteMovie();
                    break;

                case "4":
                    RetrieveById();
                    break;

                case "5":
                    RetrieveAll();
                    break;

                case "6":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    // Metodos para cada una de las opciones del menu
    // Metodo para crear una película
    private static void CreateMovie()
    {
        // Instanciamos el SqlDao y SqlOperation para realizar la operación de creación
        var sqlDao = SqlDao.GetInstance();
        var sqlOperation = new SqlOperation();

        Console.WriteLine("Ingrese el titulo:");
        var title = Console.ReadLine();

        Console.WriteLine("Ingrese la sinopsis:");
        var sinopsis = Console.ReadLine();

        Console.WriteLine("Ingrese el genero:");
        var genre = Console.ReadLine();

        Console.WriteLine("Ingrese la duracion:");
        var duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la clasificacion:");
        var classification = Console.ReadLine();

        Console.WriteLine("Ingrese la imagen:");
        var image = Console.ReadLine();

        // Creamos el DTO de película con los datos ingresados por el usuario
        var movieDTO = new Movie();
        movieDTO.Title = title;
        movieDTO.Sinopsis = sinopsis;
        movieDTO.Genre = genre;
        movieDTO.Duration = duration;
        movieDTO.Classification = classification;
        movieDTO.Image = image;
        movieDTO.Status = "AC";

        // Instanciamos el MovieCrudFactory y llamamos al método Create para registrar la película en la base de datos
        var mCrud = new MovieCrudFactory();
        mCrud.Create(movieDTO);

        Console.WriteLine("Película registrada correctamente.");
    }

    // Metodo para actualizar una película
    private static void UpdateMovie()
    {
        // Solicitamos el ID de la película a actualizar y los nuevos datos para la película
        Console.WriteLine("Ingrese el ID de la película:");
        var id = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo titulo:");
        var title = Console.ReadLine();

        Console.WriteLine("Ingrese la nueva sinopsis:");
        var sinopsis = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo genero:");
        var genre = Console.ReadLine();

        Console.WriteLine("Ingrese la nueva duracion:");
        var duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese la nueva clasificacion:");
        var classification = Console.ReadLine();

        Console.WriteLine("Ingrese la nueva imagen:");
        var image = Console.ReadLine();

        // Instanciamos el SqlDao y SqlOperation para realizar la operación de actualización
        var sqlDao = SqlDao.GetInstance();
        var sqlOperation = new SqlOperation();

        // Creamos el DTO de película con los nuevos datos ingresados por el usuario
        var movieDTO = new Movie();
        movieDTO.Id = id;
        movieDTO.Title = title;
        movieDTO.Sinopsis = sinopsis;
        movieDTO.Genre = genre;
        movieDTO.Duration = duration;
        movieDTO.Classification = classification;
        movieDTO.Image = image;
        movieDTO.Status = "AC";

        // Instanciamos el MovieCrudFactory y llamamos al método Update para actualizar la película en la base de datos
        var mCrud = new MovieCrudFactory();
        mCrud.Update(movieDTO);

        Console.WriteLine("Película actualizada correctamente.");
    }

    // Metodo para eliminar una película
    private static void DeleteMovie()
    {
        // Solicitamos el ID de la película a eliminar
        Console.WriteLine("Ingrese el ID de la película a eliminar:");
        var id = int.Parse(Console.ReadLine());

        // Instanciamos el SqlDao y SqlOperation para realizar la operación de eliminación
        var movieDTO = new Movie();
        movieDTO.Id = id;

        // Instanciamos el MovieCrudFactory y llamamos al método Delete para eliminar la película de la base de datos
        var mCrud = new MovieCrudFactory();
        mCrud.Delete(movieDTO);

        Console.WriteLine("Película eliminada correctamente.");
    }

    // Metodo para consultar una película por su ID
    private static void RetrieveById()
    {
        // Solicitamos el ID de la película a consultar
        Console.WriteLine("Ingrese el ID de la película:");
        var id = int.Parse(Console.ReadLine());

        // Instanciamos el SqlDao y SqlOperation para realizar la operación de consulta
        var mCrud = new MovieCrudFactory();
        var movie = mCrud.RetrieveById<Movie>(id);

        // Mostramos los datos de la pelicula consultado en formato JSON
        // Si la pelicula no existe, mostramos un mensaje indicando que no se encontró la pelicula
        if (movie != null)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(movie));
            Console.WriteLine("\n=== INFORMACIÓN DE LA PELÍCULA ===");
            Console.WriteLine($"ID: {movie.Id}");
            Console.WriteLine($"Created: {movie.Created}");
            Console.WriteLine($"Updated: {movie.Updated}");
            Console.WriteLine($"Título: {movie.Title}");
            Console.WriteLine($"Sinopsis: {movie.Sinopsis}");
            Console.WriteLine($"Género: {movie.Genre}");
            Console.WriteLine($"Duración: {movie.Duration} min");
            Console.WriteLine($"Clasificación: {movie.Classification}");
            Console.WriteLine($"Imagen: {movie.Image}");
            Console.WriteLine($"Estado: {movie.Status}");
        }
        else
        {
            Console.WriteLine("Película no encontrada.");
        }
    }

    // Metodo para consultar todas las películas
    private static void RetrieveAll()
    {
        Console.WriteLine("Listado de películas del aplicativo");

        // Instanciamos el MovieCrudFactory y llamamos al método RetrieveAll para obtener la lista de películas de la base de datos
        var mCrud = new MovieCrudFactory();
        var lstMovies = mCrud.RetrieveAll<Movie>();

        // Mostramos los datos de las peliculas consultadas en formato JSON
        foreach (var movie in lstMovies)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(movie));
            Console.WriteLine("========================================");
            Console.WriteLine($"ID: {movie.Id}");
            Console.WriteLine($"Created: {movie.Created}");
            Console.WriteLine($"Updated: {movie.Updated}");
            Console.WriteLine($"Título: {movie.Title}");
            Console.WriteLine($"Sinopsis: {movie.Sinopsis}");
            Console.WriteLine($"Género: {movie.Genre}");
            Console.WriteLine($"Duración: {movie.Duration} min");
            Console.WriteLine($"Clasificación: {movie.Classification}");
            Console.WriteLine($"Imagen: {movie.Image}");
            Console.WriteLine($"Estado: {movie.Status}");
            Console.WriteLine("========================================");
        }
    }

}