using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;
using DataAccess.DAO;
using Entities_DTOs;

namespace DataAccess.CRUD
{
    public class TicketCrudFactory : CrudFactory
    {
        public TicketCrudFactory()
        {
            sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            // Conviertiendo el baseDTO en un objeto ticket 
            var ticket = baseDTO as Ticket;
            // definir el SP, por medio del sql operation
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_TICKET_PR";

            sqlOperation.AddDecimalParameter("P_PRICE", ticket.Price);
            sqlOperation.AddStringParameter("P_SCHEDULE", ticket.Schedule);
            sqlOperation.AddDateTimeParameter("P_DATE", ticket.Date);
            sqlOperation.AddStringParameter("P_TYPE", ticket.Type);
            sqlOperation.AddIntParameter("P_MOVIE_ID", ticket.MovieId);
            sqlOperation.AddStringParameter("P_STATUS", ticket.Status);

            //Ejecutamos el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstTickets = new List<T>();

            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_TICKET_PR";

            var lstResult = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResult.Count > 0)
            {
                foreach (var result in lstResult)
                {
                    var ticket = BuildTicket(result);

                    lstTickets.Add((T)Convert.ChangeType(ticket, typeof(T)));
                }
            }
            return lstTickets;
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_TICKET_PR";

            sqlOperation.AddIntParameter("P_ID", ticket.Id);
            sqlOperation.AddDecimalParameter("P_PRICE", ticket.Price);
            sqlOperation.AddStringParameter("P_SCHEDULE", ticket.Schedule);
            sqlOperation.AddDateTimeParameter("P_DATE", ticket.Date);
            sqlOperation.AddStringParameter("P_TYPE", ticket.Type);
            sqlOperation.AddIntParameter("P_MOVIE_ID", ticket.MovieId);
            sqlOperation.AddStringParameter("P_STATUS", ticket.Status);

            sqlDao.ExecuteProcedure(sqlOperation);
        }


        //Metodo que construye el DTO del usuario a partir de la data que viene en la consulta de la BD
        private Ticket BuildTicket(Dictionary<string, object> row)
        {
            var ticket = new Ticket()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                Price = (decimal)row["Price"],
                Schedule = (string)row["Schedule"],
                Date = (DateTime)row["Date"],
                Type = (string)row["Type"],
                MovieId = (int)row["MovieId"],
                Status = (string)row["Status"]
            };

            return ticket;
        }

    }
}