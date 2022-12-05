using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM especialidad ORDER BY nombre;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Especialidad especialidad = new Especialidad();
                        especialidad.Id = int.Parse(dataReader["id"].ToString());
                        especialidad.Nombre = dataReader["nombre"].ToString();

                        especialidades.Add(especialidad);

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return especialidades;
        }

        public static Especialidad GetById(int id)
        {
            Especialidad especialidad = new Especialidad();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM especialidad WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        especialidad.Id = int.Parse(dataReader["id"].ToString());
                        especialidad.Nombre = dataReader["nombre"].ToString();

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return especialidad;
        }

        public static bool Guardar(int id, string nombre)
        {
            bool result = false;
            try
            {

                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();


                    if (id == 0)
                    {
                        cmd.CommandText = "INSERT INTO especialidad (nombre) VALUES (@nombre)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE especialidad SET nombre = @nombre WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                    }

                    result = cmd.ExecuteNonQuery() == 1;

                    /* if (cmd.EndExecuteNonQuery() == 1)
                     {
                         result = true;

                     }else { 
                         result = false;
                     }*/
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
