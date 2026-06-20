using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CRUD;
using Entities_DTOs;

namespace CoreApp
{
    // Logica de Negocio
    public class MovieManager
    {
        public List<Movie> RetrieveAllMovies()
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveAll<Movie>();
        }

        public void Create(Movie m)
        {
            var mCrud = new MovieCrudFactory();

            // Validaciones de forma

            if (HasEmptyFields(m))
                throw new Exception("Todos los campos son obligatorios");

            if (!IsValidDuration(m))
                throw new Exception("La duracion debe ser mayor a 0");

            if (!IsValidStatus(m))
                throw new Exception("Estado invalido (Ac o In)");

            // Validacion de negocio

            if (MovieExists(m))
                throw new Exception("La pelicula ya existe");

            mCrud.Create(m);
        }

        public void Update(Movie m)
        {
            var mCrud = new MovieCrudFactory();

            // Validaciones de forma

            if (HasEmptyFields(m))
                throw new Exception("Todos los campos son obligatorios");

            if (!IsValidDuration(m))
                throw new Exception("La duracion debe ser mayor a 0");

            if (!IsValidStatus(m))
                throw new Exception("Estado invalido (Ac o In)");

            // Validacion de negocio

            if (MovieExists(m))
                throw new Exception("Ya existe otra pelicula con ese nombre");

            mCrud.Update(m);
        }

        public void Delete(Movie m)
        {
            var mCrud = new MovieCrudFactory();
            mCrud.Delete(m);
        }


        // Validaciones de forma

        // Validar que no haya campos vacíos
        private bool HasEmptyFields(Movie movie)
        {
            return string.IsNullOrWhiteSpace(movie.Title) ||
                   string.IsNullOrWhiteSpace(movie.Sinopsis) ||
                   string.IsNullOrWhiteSpace(movie.Genre) ||
                   string.IsNullOrWhiteSpace(movie.Classification) ||
                   string.IsNullOrWhiteSpace(movie.Image) ||
                   string.IsNullOrWhiteSpace(movie.Status);
        }

        // Validar que la duración sea un número positivo
        private bool IsValidDuration(Movie movie)
        {
            return movie.Duration >= 60;
        }

        // Validar que el estado sea "Ac" o "In"
        private bool IsValidStatus(Movie movie)
        {
            return movie.Status == "Ac" || movie.Status == "In";
        }

        // Validacion de negocio

        // Validar que no exista una película con el mismo título o nombre
        private bool MovieExists(Movie m)
        {
            var mCrud = new MovieCrudFactory();
            var movies = mCrud.RetrieveAll<Movie>();

            // Busca si existe otra película con el mismo título pero diferente Id
            return movies.Any(x => x.Title == m.Title && x.Id != m.Id);
        }
    }
}