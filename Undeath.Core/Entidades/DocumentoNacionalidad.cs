using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class DocumentoNacionalidad
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<DocumentoNacionalidad> GetAll()
        {
            List<DocumentoNacionalidad> list = new List<DocumentoNacionalidad>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {

                    string query = "SELECT * FROM documento_nacionalidad";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {

                        DocumentoNacionalidad documentoNacionalidad = new DocumentoNacionalidad();
                        documentoNacionalidad.Id = int.Parse(dataReader["id"].ToString());
                        documentoNacionalidad.Nombre = dataReader["nombre"].ToString();

                        list.Add(documentoNacionalidad);
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
                    cmd.CommandText = "INSERT INTO documento_nacionalidad (nombre) VALUES (@nombre)";
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
                    //UPDATE documento_nacionalidad SET nombre = ? WHERE id = ? 
                    cmd.CommandText = "UPDATE documento_nacionalidad SET nombre = @nombre WHERE id = @id";
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
