using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;
using DataAccess.DAO;
using Entities_DTOs;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public MovieCrudFactory() {
            sqlDao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            // Conviertiendo el baseDTO en un objeto Pelicula 
            var movie = baseDTO as Movie;
            // definir el SP, por medio del sql operation
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_MOVIE_PR";

            sqlOperation.AddStringParameter("P_TITLE", movie.Title);
            sqlOperation.AddStringParameter("P_SINOPSIS", movie.Sinopsis);
            sqlOperation.AddStringParameter("P_GENRE", movie.Genre);
            sqlOperation.AddIntParameter("P_DURATION", movie.Duration);
            sqlOperation.AddStringParameter("P_CLASSIFICATION", movie.Classification);
            sqlOperation.AddStringParameter("P_IMAGE", movie.Image);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);

            //Ejecutamos el SP
            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();

            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_MOVIE_PR";

            var lstResult = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResult.Count > 0)
            {
                foreach (var result in lstResult)
                {
                    var movie = BuildMovie(result);

                    lstMovies.Add((T)Convert.ChangeType(movie, typeof(T)));
                }
            }
            return lstMovies;
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_MOVIE_PR";

            sqlOperation.AddIntParameter("P_ID", movie.Id);
            sqlOperation.AddStringParameter("P_TITLE", movie.Title);
            sqlOperation.AddStringParameter("P_SINOPSIS", movie.Sinopsis);
            sqlOperation.AddStringParameter("P_GENRE", movie.Genre);
            sqlOperation.AddIntParameter("P_DURATION", movie.Duration);
            sqlOperation.AddStringParameter("P_CLASSIFICATION", movie.Classification);
            sqlOperation.AddStringParameter("P_IMAGE", movie.Image);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        //Metodo que construye el DTO del usuario a partir de la data que viene en la consulta de la BD
        private Movie BuildMovie(Dictionary<string, object> row)
        {
            var movie = new Movie()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                Title = (string)row["Title"],
                Sinopsis = (string)row["Sinopsis"],
                Genre = (string)row["Genre"],
                Duration = (int)row["Duration"],
                Classification = (string)row["Classification"],
                Image = (string)row["Image"],
                Status = (string)row["Status"]
            };

            return movie;
        }

    }
}