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
            mCrud.Create(m);
        }
    }
}