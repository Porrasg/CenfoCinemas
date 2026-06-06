using DataAccess.DAO;

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

        sqlOperation.ProcedureName = "CRE_TICKET_PR";

        sqlOperation.AddDecimalParameter("P_PRICE", price);
        sqlOperation.AddStringParameter("P_SCHEDULE", schedule);
        sqlOperation.AddDateTimeParameter("P_DATE", date);
        sqlOperation.AddStringParameter("P_TYPE", type);
        sqlOperation.AddIntParameter("P_MOVIE_ID", movieId);
        sqlOperation.AddStringParameter("P_STATUS", "AC");

        sqlDao.ExecuteProcedure(sqlOperation);

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

        var sqlDao = SqlDao.GetInstance();
        var sqlOperation = new SqlOperation();

        sqlOperation.ProcedureName = "UPD_TICKET_PR";

        sqlOperation.AddIntParameter("P_ID", id);
        sqlOperation.AddDecimalParameter("P_PRICE", price);
        sqlOperation.AddStringParameter("P_SCHEDULE", schedule);
        sqlOperation.AddDateTimeParameter("P_DATE", date);
        sqlOperation.AddStringParameter("P_TYPE", type);
        sqlOperation.AddIntParameter("P_MOVIE_ID", movieId);
        sqlOperation.AddStringParameter("P_STATUS", "AC");

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Ticket actualizado correctamente.");
    }
}