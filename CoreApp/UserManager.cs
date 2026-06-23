using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DataAccess.CRUD;
using Entities_DTOs;

namespace CoreApp
{
    // Logica de Negocio
    public class UserManager
    {
        public List<User> RetrieveAllUsers()
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveAll<User>();
        }

        public void Create(User u)
        {
            var uCrud = new UserCrudFactory();

            // Validaciones de forma
            if (u == null)
                throw new Exception("Usuario no puede ser nulo");

            if (HasEmptyFields(u))
                throw new Exception("Todos los campos son obligatorios");

            if (!IsValidEmail(u))
                throw new Exception("Correo electronico invalido");

            if (!IsValidPassword(u))
                throw new Exception("La contraseña debe tener al menos 6 caracteres");

            if (!IsValidBirthDate(u))
                throw new Exception("La fecha de nacimiento no puede ser futura");

            if (!IsValidPhone(u))
                throw new Exception("Numero de telefono invalido");

            // Validaciones de negocio
            if (!IsOver18(u))
                throw new Exception("Usuario no cumple con la edad minima para el registro");

            if (!IsValidStatus(u))
                throw new Exception("Estado inválido. Valores permitidos: Activo (Ac) o Inactivo (In)");

            if (EmailExists(u))
                throw new Exception("El correo ya está registrado");

            if (UserCodeExists(u))
                throw new Exception("El código de usuario ya existe");


            uCrud.Create(u);
        }

        public void Update(User u)
        {
            var uCrud = new UserCrudFactory();

            // Validaciones de forma
            if (u == null)
                throw new Exception("Usuario no puede ser nulo");

            if (HasEmptyFields(u))
                throw new Exception("Todos los campos son obligatorios");

            if (!IsValidEmail(u))
                throw new Exception("Correo electronico invalido");

            if (!IsValidPassword(u))
                throw new Exception("La contraseña debe tener al menos 6 caracteres");

            if (!IsValidBirthDate(u))
                throw new Exception("La fecha de nacimiento no puede ser futura");

            if (!IsValidPhone(u))
                throw new Exception("Numero de telefono invalido");


            // Validaciones de negocio
            if (!IsOver18(u))
                throw new Exception("Usuario no cumple con la edad minima para el registro");

            if (!IsValidStatus(u))
                throw new Exception("Estado inválido. Valores permitidos: Activo (Ac) o Inactivo (In)");

            if (EmailExists(u))
                throw new Exception("El correo ya está registrado");

            if (UserCodeExists(u))
                throw new Exception("El código de usuario ya existe");


            uCrud.Update(u);
        }

        public void Delete(User u)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Delete(u);
        }

        // Validaciones de Negocio
        // Verificar que el usuario tenga al menos 18 años
        private bool IsOver18(User user)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate > currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;
        }

        // Verificar que el estado sea "Ac" o "In"
        private bool IsValidStatus(User user)
        {
            return user.Status.ToUpper() == "AC" || user.Status.ToUpper() == "IN";
        }

        // Validaciones de Forma

        // Verificar que no haya campos vacíos
        private bool HasEmptyFields(User user)
        {
            return string.IsNullOrWhiteSpace(user.UserCode) ||
                   string.IsNullOrWhiteSpace(user.Name) ||
                   string.IsNullOrWhiteSpace(user.Email) ||
                   string.IsNullOrWhiteSpace(user.Password) ||
                   string.IsNullOrWhiteSpace(user.Status);
        }

        // Verificar que el correo electrónico tenga un formato válido
        private bool IsValidEmail(User user)
        {
            return Regex.IsMatch(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // Verificar que la contraseña tenga al menos 6 caracteres
        private bool IsValidPassword(User user)
        {
            return !string.IsNullOrWhiteSpace(user.Password)
                   && user.Password.Length >= 6;
        }

        // Verificar que la fecha de nacimiento no sea futura
        private bool IsValidBirthDate(User user)
        {
            return user.BirthDate <= DateTime.Now;
        }

        // Verificar que el número de teléfono sea un número positivo
        private bool IsValidPhone(User user)
        {
            return user.PhoneNumber > 0;
        }

        // Verificar que el correo electrónico no esté registrado
        private bool EmailExists(User user)
        {
            var uCrud = new UserCrudFactory();
            var users = uCrud.RetrieveAll<User>();

            // Busca si existe otro usuario con el mismo correo pero diferente Id
            return users.Any(u => u.Email == user.Email && u.Id != user.Id);
        }

        // Verificar que el código de usuario no exista
        private bool UserCodeExists(User user)
        {
            var uCrud = new UserCrudFactory();
            var users = uCrud.RetrieveAll<User>();

            // Busca si existe otro usuario con el mismo código pero diferente Id
            return users.Any(u => u.UserCode == user.UserCode && u.Id != user.Id);
        }


    }
}