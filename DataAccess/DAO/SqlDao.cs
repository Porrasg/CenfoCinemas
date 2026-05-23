using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DataAccess.DAO
{
    /*
        Clase que se encarga de la comunicacion con la base de datos
        Solo ejecuta Store procedures

        Implementa el patron del singleton, para asegurar la existencia de un unino
        objeto que se conecta a la base de datos y centraliza esta gestion.
    */

    public class SqlDao
    {
        // Paso 1: Crear una instancia privada de esta misma clase
        private static SqlDao instance;

        private string connectionString; // Cadena de conexion a la base de datos

        // Paso 2: Redefinir el constructor default de la clase
        private SqlDao(){

            connectionString = string.Empty;
        }

        // Paso 3: Definir un metodo estatico que expone la instancia
        public static SqlDao GetInstance() {
            if (instance == null) {
                instance = new SqlDao();
            }

            return instance;
        }

        // Metodo que ejecuta stored procedure en la base de datos, a partir de la especificacion
        // recibida por parametro
        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure 
                })
                {
                    // Set de los parametros que utiliza el SP
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }
                    //Ejecuta el SP
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                    
            }
        }

    }
}
