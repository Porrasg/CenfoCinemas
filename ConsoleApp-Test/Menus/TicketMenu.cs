using System.Net.Sockets;
using DataAccess.CRUD;
using DataAccess.DAO;
using Entities_DTOs;
using Newtonsoft.Json;

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
            Console.WriteLine("4. Consultar un Ticket");
            Console.WriteLine("5. Consultar todos los Ticket");
            Console.WriteLine("6. Volver");
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
                    DeleteTicket();
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
    // Metodo para crear un ticket
    private static void CreateTicket()
    {
        // Instanciamos el SqlDao y el SqlOperation para realizar la operación de creación
        var sqlDao = SqlDao.GetInstance();
        var sqlOperation = new SqlOperation();

        // Solicitamos al usuario los datos necesarios para crear el ticket
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

        // Creamos el DTO del ticket con los datos ingresados por el usuario
        var ticketDTO = new Ticket();
        ticketDTO.Price = price;
        ticketDTO.Schedule = schedule;
        ticketDTO.Date = date;
        ticketDTO.Type = type;
        ticketDTO.MovieId = movieId;
        ticketDTO.Status = "AC";

        // Utilizamos el TicketCrudFactory para crear el ticket en la base de datos
        var tCrud = new TicketCrudFactory();
        tCrud.Create(ticketDTO);

        Console.WriteLine("Ticket registrado correctamente.");
    }

    // Metodo para actualizar un ticket
    private static void UpdateTicket()
    {
        // Solicitamos al usuario el ID del ticket que desea actualizar y los nuevos datos
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

        // Creamos el DTO del ticket con los nuevos datos ingresados por el usuario
        var ticketDTO = new Ticket();
        ticketDTO.Id = id;
        ticketDTO.Price = price;
        ticketDTO.Schedule = schedule;
        ticketDTO.Date = date;
        ticketDTO.Type = type;
        ticketDTO.MovieId = movieId;
        ticketDTO.Status = "AC";

        // Utilizamos el TicketCrudFactory para actualizar el ticket en la base de datos
        var tCrud = new TicketCrudFactory();
        tCrud.Update(ticketDTO);

        Console.WriteLine("Ticket actualizado correctamente.");
    }

    // Metodo para eliminar un ticket
    private static void DeleteTicket()
    {
        // Solicitamos al usuario el ID del ticket que desea eliminar
        Console.WriteLine("Ingrese el ID del ticket a eliminar:");
        var id = int.Parse(Console.ReadLine());

        // Creamos el DTO del ticket con el ID ingresado por el usuario
        var ticketDTO = new Ticket();
        ticketDTO.Id = id;

        // Utilizamos el TicketCrudFactory para eliminar el ticket de la base de datos
        var tCrud = new TicketCrudFactory();
        tCrud.Delete(ticketDTO);

        Console.WriteLine("Ticket eliminado correctamente.");
    }

    // Metodo para consultar un ticket por su ID
    private static void RetrieveById()
    {
        // Solicitamos al usuario el ID del ticket que desea consultar
        Console.WriteLine("Ingrese el ID del ticket:");
        var id = int.Parse(Console.ReadLine());

        // Utilizamos el TicketCrudFactory para consultar el ticket por su ID en la base de datos
        var tCrud = new TicketCrudFactory();
        var ticket = tCrud.RetrieveById<Ticket>(id);

        // Mostramos los datos del ticket consultado en formato JSON
        // // Si el ticket no existe, mostramos un mensaje indicando que no se encontró el ticket
        if (ticket != null)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(ticket));
            Console.WriteLine("\n=== INFORMACIÓN DEL TICKET ===");
            Console.WriteLine($"ID: {ticket.Id}");
            Console.WriteLine($"Created: {ticket.Created}");
            Console.WriteLine($"Updated: {ticket.Updated}");
            Console.WriteLine($"Precio: ₡{ticket.Price:N2}");
            Console.WriteLine($"Horario: {ticket.Schedule}");
            Console.WriteLine($"Fecha: {ticket.Date:dd/MM/yyyy}");
            Console.WriteLine($"Tipo: {ticket.Type}");
            Console.WriteLine($"Película ID: {ticket.MovieId}");
            Console.WriteLine($"Estado: {ticket.Status}");
        }
        else
        {
            Console.WriteLine("Ticket no encontrado.");
        }
    }

    // Metodo para consultar todos los tickets
    private static void RetrieveAll()
    {
        Console.WriteLine("Listado de tickets del aplicativo");

        // Obtenemos la lista de tickets utilizando el método RetrieveAll del TicketCrudFactory
        var tCrud = new TicketCrudFactory();
        var lstTickets = tCrud.RetrieveAll<Ticket>();

        // Mostramos los datos de cada ticket en formato JSON
        foreach (var ticket in lstTickets)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(ticket));
            Console.WriteLine("========================================");
            Console.WriteLine($"ID: {ticket.Id}");
            Console.WriteLine($"Created: {ticket.Created}");
            Console.WriteLine($"Updated: {ticket.Updated}");
            Console.WriteLine($"Precio: {ticket.Price:N2}");
            Console.WriteLine($"Horario: {ticket.Schedule}");
            Console.WriteLine($"Fecha: {ticket.Date:dd/MM/yyyy}");
            Console.WriteLine($"Tipo: {ticket.Type}");
            Console.WriteLine($"Película ID: {ticket.MovieId}");
            Console.WriteLine($"Estado: {ticket.Status}");
            Console.WriteLine("========================================");
        }
    }

}