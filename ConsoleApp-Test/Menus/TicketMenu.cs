using DataAccess.CRUD;
using DataAccess.DAO;
using Entities_DTOs;

namespace ConsoleApp_Test.Menus;

public static class TicketMenu
{
    public static void Menu()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();

            Console.WriteLine("=== TICKETS ===");
            Console.WriteLine("1. Crear Ticket");
            Console.WriteLine("2. Actualizar Ticket");
            Console.WriteLine("3. Eliminar Ticket");
            Console.WriteLine("4. Consultar Ticket");
            Console.WriteLine("5. Volver");
            Console.Write("\nSeleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CreateTicket();
                    break;

                case "2":
                    UpdateTicket();
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

    private static void CreateTicket()
    {
        var sqlDao = SqlDao.GetInstance();
        var sqlOperation = new SqlOperation();

        Console.WriteLine("Ingrese el precio:");
        var price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el horario:");
        var schedule = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha:");
        var date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el tipo:");
        var type = Console.ReadLine();

        Console.WriteLine("Ingrese el Id de la pelicula:");
        var movieId = int.Parse(Console.ReadLine());

        var ticketDTO = new Ticket();
        ticketDTO.Price = price;
        ticketDTO.Schedule = schedule;
        ticketDTO.Date = date;
        ticketDTO.Type = type;
        ticketDTO.MovieId = movieId;
        ticketDTO.Status = "AC";

        var tCrud = new TicketCrudFactory();
        tCrud.Create(ticketDTO);

        Console.WriteLine("Ticket registrado correctamente.");
    }

    private static void UpdateTicket()
    {
        Console.WriteLine("Ingrese el ID del ticket:");
        var id = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo precio:");
        var price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo horario:");
        var schedule = Console.ReadLine();

        Console.WriteLine("Ingrese la nueva fecha:");
        var date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo tipo:");
        var type = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo Id de la película:");
        var movieId = int.Parse(Console.ReadLine());

        var ticketDTO = new Ticket();
        ticketDTO.Id = id;
        ticketDTO.Price = price;
        ticketDTO.Schedule = schedule;
        ticketDTO.Date = date;
        ticketDTO.Type = type;
        ticketDTO.MovieId = movieId;
        ticketDTO.Status = "AC";

        var tCrud = new TicketCrudFactory();
        tCrud.Update(ticketDTO);

        Console.WriteLine("Ticket actualizado correctamente.");
    }
}