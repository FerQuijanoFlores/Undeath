using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Tramite
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<Tramite> GetAll()
        {
            List<Tramite> tramites = new List<Tramite>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM tramite;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Tramite tramite = new Tramite();
                        tramite.Id = int.Parse(dataReader["id"].ToString());
                        tramite.Nombre = dataReader["nombre"].ToString();

                        tramites.Add(tramite);

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tramites;
        }

    }
}
