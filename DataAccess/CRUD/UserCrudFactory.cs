using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;
using DataAccess.DAO;
using Entities_DTOs;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {

        public UserCrudFactory() {
            sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            // Conviertiendo el baseDTO en un objeto Usuario 
            var user = baseDTO as User;
            // definir el SP, por medio del sql operation
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_USER_PR";

            sqlOperation.AddStringParameter("P_USER_CODE", user.UserCode);
            sqlOperation.AddStringParameter("P_NAME", user.Name);
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);
            sqlOperation.AddStringParameter("P_PASSWORD", user.Password);
            sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddStringParameter("P_STATUS", user.Status);
            sqlOperation.AddIntParameter("P_PHONE_NUMBER", user.PhoneNumber);

            //Ejecutamos el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            // Convirtiendo el BaseDTO en un objeto User
            var user = baseDTO as User;

            // Definir el SP
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_USER_PR";

            sqlOperation.AddIntParameter("P_ID", user.Id);

            // Ejecutar el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            // Lista que va a contener a todos los usuarios que se obtengan de la consulta a la BD
            var lstUsers = new List<T>();

            // Definir el SP
            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_USER_PR";

            // Ejecutar el SP
            var lstResult = sqlDao.ExecuteQueryProcedure(operation);

            // Recorrer la lista de resultados y convertir cada fila en un objeto User, luego agregarlo a la lista de usuarios
            if (lstResult.Count > 0)
            {
                foreach (var result in lstResult)
                {
                    var user = BuildUser(result);

                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T))); 
                }
            }
            return lstUsers;
        }

        public override T RetrieveById<T>(int id)
        {
            // Definir el SP
            var operation = new SqlOperation();
            operation.ProcedureName = "RET_USER_BY_ID_PR";

            operation.AddIntParameter("P_ID", id);

            // Ejecutar el SP
            var lstResult = sqlDao.ExecuteQueryProcedure(operation);

            // Si se obtiene un resultado, convertir la primera fila en un objeto User y devolverlo, de lo contrario devolver null
            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }

            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            // Convirtiendo el BaseDTO en un objeto User
            var user = baseDTO as User;

            // Definir el SP
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_USER_PR";

            sqlOperation.AddIntParameter("P_ID", user.Id);
            sqlOperation.AddStringParameter("P_USER_CODE", user.UserCode);
            sqlOperation.AddStringParameter("P_NAME", user.Name);
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);
            sqlOperation.AddStringParameter("P_PASSWORD", user.Password);
            sqlOperation.AddDateTimeParameter("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddStringParameter("P_STATUS", user.Status);
            sqlOperation.AddIntParameter("P_PHONE_NUMBER", user.PhoneNumber);

            // Ejecutar el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        //Metodo que construye el DTO del usuario a partir de la data que viene en la consulta de la BD
        private User BuildUser(Dictionary<string, object> row)
        {
            // Crea un nuevo objeto User y asigna sus propiedades a partir de los valores del diccionario
            var user = new User()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                UserCode = (string)row["UserCode"],
                Name = (string)row["Name"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                BirthDate = (DateTime)row["BirthDate"],
                Status = (string)row["Status"],
                PhoneNumber = (int)row["PhoneNumber"]
            };
            return user;
        }
        
    }
}
