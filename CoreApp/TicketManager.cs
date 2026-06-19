using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CRUD;
using Entities_DTOs;

namespace CoreApp
{
    // Logica de Negocio
    public class TicketManager
    {
        public List<Ticket> RetrieveAllTickets()
        {
            var tCrud = new TicketCrudFactory();
            return tCrud.RetrieveAll<Ticket>();
        }

        public void Create(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Create(t);
        }
    }
}