using System;
using System.Collections.Generic;
using System.Text;
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

    }
}
