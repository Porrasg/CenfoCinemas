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
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();

            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_USER_PR";

            var lstResult = sqlDao.ExecuteQueryProcedure(operation);

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
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

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

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        //Metodo que construye el DTO del usuario a partir de la data que viene en la consulta de la BD
        private User BuildUser(Dictionary<string, object> row)
        {
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
