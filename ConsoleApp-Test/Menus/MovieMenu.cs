using DataAccess.CRUD;
using DataAccess.DAO;
using Entities_DTOs;

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
            Console.WriteLine("4. Consultar Película");
            Console.WriteLine("5. Volver");
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
                    Console.WriteLine("Pendiente...");
                    break;

                case "4":
                    Console.WriteLine("Pendiente...");
                    break;

                case "5":
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

    private static void CreateMovie()
    {
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

        var movieDTO = new Movie();
        movieDTO.Title = title;
        movieDTO.Sinopsis = sinopsis;
        movieDTO.Genre = genre;
        movieDTO.Duration = duration;
        movieDTO.Classification = classification;
        movieDTO.Image = image;
        movieDTO.Status = "AC";

        var mCrud = new MovieCrudFactory();
        mCrud.Create(movieDTO);

        Console.WriteLine("Película registrada correctamente.");
    }

    private static void UpdateMovie()
    {
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

        var sqlDao = SqlDao.GetInstance();
        var sqlOperation = new SqlOperation();

        var movieDTO = new Movie();
        movieDTO.Id = id;
        movieDTO.Title = title;
        movieDTO.Sinopsis = sinopsis;
        movieDTO.Genre = genre;
        movieDTO.Duration = duration;
        movieDTO.Classification = classification;
        movieDTO.Image = image;
        movieDTO.Status = "AC";

        var mCrud = new MovieCrudFactory();
        mCrud.Update(movieDTO);

        Console.WriteLine("Película actualizada correctamente.");
    }
}