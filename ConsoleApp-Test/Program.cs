using DataAccess.DAO;

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
            Console.Write("Seleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CreateUser();
                    break;

                case "2":
                    CreateMovie();
                    break;

                case "3":
                    CreateTicket();
                    break;

                case "4":
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

    private static void CreateUser()
    {
        var sqlDao = SqlDao.GetInstance();
        var sqlOperation = new SqlOperation();

        Console.WriteLine("Ingrese el codigo de usuario:");
        var userCode = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre completo:");
        var name = Console.ReadLine();

        Console.WriteLine("Ingrese el email:");
        var email = Console.ReadLine();

        Console.WriteLine("Ingrese la contraseña:");
        var pwd = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha de nacimiento (DD-MM-YYYY):");
        var birthDate = DateTime.Parse(Console.ReadLine());

        var status = "AC"; // AC = Activo  IN = Inactivo

        Console.WriteLine("Ingrese el telefono:");
        var phone = int.Parse(Console.ReadLine());

        sqlOperation.ProcedureName = "CRE_USER_PR";
        sqlOperation.AddStringParameter("P_USER_CODE", userCode);
        sqlOperation.AddStringParameter("P_NAME", name);
        sqlOperation.AddStringParameter("P_EMAIL", email);
        sqlOperation.AddStringParameter("P_PASSWORD", pwd);
        sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", birthDate);
        sqlOperation.AddStringParameter("P_STATUS", status);
        sqlOperation.AddIntParameter("P_PHONE_NUMBER", phone);

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Usuario registrado correctamente.");
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

        var status = "AC";

        sqlOperation.ProcedureName = "CRE_MOVIE_PR";
        sqlOperation.AddStringParameter("P_TITLE", title);
        sqlOperation.AddStringParameter("P_SINOPSIS", sinopsis);
        sqlOperation.AddStringParameter("P_GENRE", genre);
        sqlOperation.AddIntParameter("P_DURATION", duration);
        sqlOperation.AddStringParameter("P_CLASSIFICATION", classification);
        sqlOperation.AddStringParameter("P_IMAGE", image);
        sqlOperation.AddStringParameter("P_STATUS", status);

        sqlDao.ExecuteProcedure(sqlOperation);
    }

    private static void CreateTicket()
    {
        var sqlDao = SqlDao.GetInstance();

        var sqlOperation = new SqlOperation();

        Console.WriteLine("Ingrese el precio:");
        var price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el horario:");
        var schedule = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha (DD-MM-YYYY):");
        var date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el tipo de ticket (Adult/Kids):");
        var type = Console.ReadLine();

        Console.WriteLine("Ingrese el Id de la película:");
        var movieId = int.Parse(Console.ReadLine());

        var status = "AC";

        sqlOperation.ProcedureName = "CRE_TICKET_PR";

        sqlOperation.AddDecimalParameter("P_PRICE", price);
        sqlOperation.AddStringParameter("P_SCHEDULE", schedule);
        sqlOperation.AddDateTimeParameter("P_DATE", date);
        sqlOperation.AddStringParameter("P_TYPE", type);
        sqlOperation.AddIntParameter("P_MOVIE_ID", movieId);
        sqlOperation.AddStringParameter("P_STATUS", status);

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Ticket registrado correctamente.");
    }
}