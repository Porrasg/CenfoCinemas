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
            Console.WriteLine("5. Consultar todos los Usuarios");
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
                    DeleteUser();
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
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    // Metodos para cada una de las opciones del menu
    //Metodo para crear un usuario
    private static void CreateUser()
    {
        //Solicitamos al usuario que ingrese los datos necesarios para crear un nuevo usuario
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

        // Creamos un objeto UserDTO con los datos ingresados por el usuario
        var userDTO = new User();
        userDTO.UserCode = userCode;
        userDTO.Name = name;
        userDTO.Email = email;
        userDTO.Password = pwd;
        userDTO.BirthDate = birthDate;
        userDTO.Status = status;
        userDTO.PhoneNumber = phone;

        // Instanciamos el UserCrudFactory y llamamos al metodo Create para registrar el nuevo usuario en la base de datos
        var uCrud = new UserCrudFactory();
        uCrud.Create(userDTO);

        Console.WriteLine("Usuario registrado correctamente.");
    }

    //Metodo para actualizar un usuario
    private static void UpdateUser()
    {
        //Solicitamos al usuario que ingrese el ID del usuario a actualizar y los nuevos datos para actualizar el usuario
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

        // Creamos un objeto UserDTO con los nuevos datos ingresados por el usuario
        var userDTO = new User();
        userDTO.Id = id;
        userDTO.UserCode = userCode;
        userDTO.Name = name;
        userDTO.Email = email;
        userDTO.Password = pwd;
        userDTO.BirthDate = birthDate;
        userDTO.Status = "AC";
        userDTO.PhoneNumber = phone;

        // Instanciamos el UserCrudFactory y llamamos al metodo Update para actualizar el usuario en la base de datos
        var uCrud = new UserCrudFactory();
        uCrud.Update(userDTO);

        Console.WriteLine("Usuario actualizado correctamente.");
    }

    //Metodo para eliminar un usuario
    private static void DeleteUser()
    {
        //Solicitamos al usuario que ingrese el ID del usuario a eliminar
        Console.WriteLine("Ingrese el ID del usuario a eliminar:");
        var id = int.Parse(Console.ReadLine());

        // Creamos un objeto UserDTO con el ID del usuario a eliminar
        var userDTO = new User();
        userDTO.Id = id;

        // Instanciamos el UserCrudFactory y llamamos al metodo Delete para eliminar el usuario de la base de datos
        var uCrud = new UserCrudFactory();
        uCrud.Delete(userDTO);

        Console.WriteLine("Usuario eliminado correctamente.");
    }

    //Metodo para consultar un usuario por ID
    private static void RetrieveById()
    {
        //Solicitamos al usuario que ingrese el ID del usuario a consultar
        Console.WriteLine("Ingrese el ID del usuario:");
        var id = int.Parse(Console.ReadLine());

        // Instanciamos el UserCrudFactory y llamamos al metodo RetrieveById para obtener los datos del usuario consultado
        var uCrud = new UserCrudFactory();
        var user = uCrud.RetrieveById<User>(id);

        // Mostramos los datos del usuario consultado en formato JSON
        // Si el usuario no existe, mostramos un mensaje indicando que no se encontró el usuario
        if (user != null)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(user));
            Console.WriteLine("\n=== INFORMACIÓN DEL USUARIO ===");
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Created: {user.Created}");
            Console.WriteLine($"Updated: {user.Updated}");
            Console.WriteLine($"Código: {user.UserCode}");
            Console.WriteLine($"Nombre: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Fecha Nacimiento: {user.BirthDate:dd/MM/yyyy}");
            Console.WriteLine($"Teléfono: {user.PhoneNumber}");
            Console.WriteLine($"Estado: {user.Status}");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado.");
        }
    }

    //Metodo para consultar todos los usuarios
    private static void RetrieveAll()
    {
        Console.WriteLine("Listado de usuarios del aplicativo");

        //Instanciamos el crud factory y llamamos al metodo RetrieveAll para obtener la lista de usuarios
        var uCrud = new UserCrudFactory();
        var lstUsers = uCrud.RetrieveAll<User>();

        // Mostramos los datos de los usuarios consultadas en formato JSON
        foreach (var user in lstUsers)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(user));
            Console.WriteLine("========================================");
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Created: {user.Created}");
            Console.WriteLine($"Updated: {user.Updated}");
            Console.WriteLine($"Código: {user.UserCode}");
            Console.WriteLine($"Nombre: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Fecha Nacimiento: {user.BirthDate:dd/MM/yyyy}");
            Console.WriteLine($"Teléfono: {user.PhoneNumber}");
            Console.WriteLine($"Estado: {user.Status}");
            Console.WriteLine("========================================");
        }    
    }

}