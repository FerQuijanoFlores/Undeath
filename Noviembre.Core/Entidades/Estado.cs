using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nómbre { get; set; }

        public static List<Estado> GetAll() {
            List<Estado> list = new List<Estado>();
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {

                    string query = "SELECT * FROM estado";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read()) {

                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["id"].ToString());
                        estado.Nómbre = dataReader["nombre"].ToString();

                        list.Add(estado);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
                ;
            } catch (Exception ex) {
                throw ex;
            }


            return list;
        }

        public bool Guardar(string nombre)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if(conexion.CloseConnection())
                {
                    MySqlCommand command = conexion.connection.CreateCommand();
                    command.CommandText = "INSERT INTO estado (nombre) VALUES (@nombre)";
                    command.Parameters.AddWithValue("@nombre", nombre);

                    result = command.ExecuteNonQuery() == 1;
                }

            }
            catch (Exception ex) {

                throw ex; 
                }
            return result;
            }

        public bool Editar(string nombre, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.CloseConnection())
                {
                    MySqlCommand command = conexion.connection.CreateCommand();
                    command.CommandText = "UPDATE estado SET nombre = (@nombre) WHERE (@id)";

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", nombre);

                    result = command.ExecuteNonQuery() == 1;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;

        }

    }
}
