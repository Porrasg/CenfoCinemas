using ConsoleApp_Test.Menus;

public class Program
{
    public static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();

            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Users");
            Console.WriteLine("2. Movies");
            Console.WriteLine("3. Tickets");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    UserMenu.Menu();
                    break;

                case "2":
                    MovieMenu.Menu();
                    break;

                case "3":
                    TicketMenu.Menu();
                    break;

                case "4":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}