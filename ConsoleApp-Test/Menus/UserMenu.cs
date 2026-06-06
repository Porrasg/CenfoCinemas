using DataAccess.DAO;

namespace ConsoleApp_Test.Menus;

public static class UserMenu
{
    public static void Menu()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();

            Console.WriteLine("=== USERS ===");
            Console.WriteLine("1. Crear Usuario");
            Console.WriteLine("2. Actualizar Usuario");
            Console.WriteLine("3. Eliminar Usuario");
            Console.WriteLine("4. Consultar Usuario");
            Console.WriteLine("5. Volver");
            Console.Write("\nSeleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CreateUser();
                    break;

                case "2":
                    UpdateUser();
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

        var status = "AC";

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

    private static void UpdateUser()
    {
        Console.WriteLine("Ingrese el ID del usuario:");
        var id = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo codigo:");
        var userCode = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo nombre:");
        var name = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo email:");
        var email = Console.ReadLine();

        Console.WriteLine("Ingrese la nueva contraseña:");
        var pwd = Console.ReadLine();

        Console.WriteLine("Ingrese la fecha de nacimiento:");
        var birthDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el telefono:");
        var phone = int.Parse(Console.ReadLine());

        var sqlDao = SqlDao.GetInstance();
        var sqlOperation = new SqlOperation();

        sqlOperation.ProcedureName = "UPD_USER_PR";

        sqlOperation.AddIntParameter("P_ID", id);
        sqlOperation.AddStringParameter("P_USER_CODE", userCode);
        sqlOperation.AddStringParameter("P_NAME", name);
        sqlOperation.AddStringParameter("P_EMAIL", email);
        sqlOperation.AddStringParameter("P_PASSWORD", pwd);
        sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", birthDate);
        sqlOperation.AddStringParameter("P_STATUS", "AC");
        sqlOperation.AddIntParameter("P_PHONE_NUMBER", phone);

        sqlDao.ExecuteProcedure(sqlOperation);

        Console.WriteLine("Usuario actualizado correctamente.");
    }
}