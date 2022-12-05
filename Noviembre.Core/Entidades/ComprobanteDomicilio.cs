using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class ComprobanteDomicilio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<ComprobanteDomicilio> GetAll()
        {
            List<ComprobanteDomicilio> list = new List<ComprobanteDomicilio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {

                    string query = "SELECT * FROM comprobante_domicilio";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {

                        ComprobanteDomicilio comprobanteDomicilio = new ComprobanteDomicilio();
                        comprobanteDomicilio.Id = int.Parse(dataReader["id"].ToString());
                        comprobanteDomicilio.Nombre = dataReader["nombre"].ToString();

                        list.Add(comprobanteDomicilio);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
                ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public static bool Guardar(string nombre)
        {
            bool result = false;
            try
            {

                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO comprobante_domicilio (nombre) VALUES (@nombre)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    result = cmd.ExecuteNonQuery() == 1;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Editar(int id, string nombre)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    cmd.CommandText = "UPDATE comprobante_domicilio SET nombre = @nombre WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    result = cmd.ExecuteNonQuery() == 1;
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
