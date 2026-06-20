using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.CRUD;
using Entities_DTOs;

namespace CoreApp
{
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

            // Validaciones de forma
            if (t == null)
                throw new Exception("El ticket no puede ser nulo");

            if (HasEmptyFields(t))
                throw new Exception("Todos los campos son obligatorios");

            if (!IsValidPrice(t))
                throw new Exception("El precio debe ser mayor a 0");

            if (!IsValidType(t))
                throw new Exception("Tipo invalido (Adult o Kids)");

            if (!IsValidDate(t))
                throw new Exception("La fecha no puede ser en el pasado");

            if (!IsValidStatus(t))
                throw new Exception("Estado inválido. Valores permitidos: Activo (Ac) o Inactivo (In)");

            // Validaciones de negocio

            if (!MovieExists(t))
                throw new Exception("La pelicula no existe");

            tCrud.Create(t);
        }

        public void Update(Ticket t)
        {
            var tCrud = new TicketCrudFactory();

            // Validaciones de forma

            if (t == null)
                throw new Exception("El ticket no puede ser nulo");

            if (HasEmptyFields(t))
                throw new Exception("Todos los campos son obligatorios");

            if (!IsValidPrice(t))
                throw new Exception("El precio debe ser mayor a 0");

            if (!IsValidType(t))
                throw new Exception("Tipo invalido (Adult o Kids)");

            if (!IsValidDate(t))
                throw new Exception("La fecha no puede ser en el pasado");

            if (!IsValidStatus(t))
                throw new Exception("Estado inválido. Valores permitidos: Activo (Ac) o Inactivo (In)");

            // Validaciones de negocio

            if (!MovieExists(t))
                throw new Exception("La pelicula no existe");

            tCrud.Update(t);
        }

        public void Delete(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Delete(t);
        }

        // validaciones de forma

        // Verificar que no haya campos vacios
        private bool HasEmptyFields(Ticket t)
        {
            return string.IsNullOrWhiteSpace(t.Schedule) ||
                   string.IsNullOrWhiteSpace(t.Type) ||
                   t.MovieId <= 0 ||
                   string.IsNullOrWhiteSpace(t.Status);
        }

        // El precio debe ser mayor a 0
        private bool IsValidPrice(Ticket t)
        {
            return t.Price > 0;
        }

        // El tipo solo puede ser "Adult" o "Kids"
        private bool IsValidType(Ticket t)
        {
            return t.Type == "Adult" || t.Type == "Kids";
        }

        // La fecha no puede ser en el pasado, pero si puede ser hoy
        private bool IsValidDate(Ticket t)
        {
            return t.Date >= DateTime.Now.Date; 
        }

        // El estado solo puede ser "Ac" o "In"
        private bool IsValidStatus(Ticket t)
        {
            return t.Status.ToUpper() == "AC" || t.Status.ToUpper() == "IN";
        }

        // Validaciones de negocio

        // Verificar que la pelicula exista antes de crear o actualizar un ticket
        private bool MovieExists(Ticket t)
        {
            var mCrud = new MovieCrudFactory();
            var movies = mCrud.RetrieveAll<Movie>();

            return movies.Any(m => m.Id == t.MovieId);
        }
    }
}