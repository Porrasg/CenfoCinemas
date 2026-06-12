using System.Net.NetworkInformation;
using System.Xml.Linq;
using DataAccess.CRUD;
using DataAccess.DAO;
using Entities_DTOs;
using Newtonsoft.Json;

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
            Console.WriteLine("4. Consultar Un Usuario");
            Console.WriteLine("5. Consultar Usuarios");
            Console.WriteLine("6. Volver");
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
                    RetrieveAll();
                    break;

                case "6":
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

        var userDTO = new User();
        userDTO.UserCode = userCode;
        userDTO.Name = name;
        userDTO.Email = email;
        userDTO.Password = pwd;
        userDTO.BirthDate = birthDate;
        userDTO.Status = status;
        userDTO.PhoneNumber = phone;

        var uCrud = new UserCrudFactory();
        uCrud.Create(userDTO);

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

        var userDTO = new User();
        userDTO.Id = id;
        userDTO.UserCode = userCode;
        userDTO.Name = name;
        userDTO.Email = email;
        userDTO.Password = pwd;
        userDTO.BirthDate = birthDate;
        userDTO.Status = "AC";
        userDTO.PhoneNumber = phone;

        var uCrud = new UserCrudFactory();
        uCrud.Update(userDTO);

        Console.WriteLine("Usuario actualizado correctamente.");
    }


    private static void RetrieveAll()
    {
        Console.WriteLine("Listado de usuarios del aplicativo");

        var uCrud = new UserCrudFactory();
        var lstUsers = uCrud.RetrieveAll<User>();

        foreach (var user in lstUsers)
        {
            Console.WriteLine(JsonConvert.SerializeObject(user));
        }    
    }

}