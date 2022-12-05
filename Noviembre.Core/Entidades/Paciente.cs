using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string apellido { get; set; }
        public string nss { get; set; }
        public string curp { get; set; }
        public string email { get; set; }

        public static List<Paciente> GetAll()
        {
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM paciente ORDER BY nombre;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Paciente paciente = new Paciente();
                        paciente.Id = int.Parse(dataReader["id"].ToString());
                        paciente.Nombre = dataReader["nombre"].ToString();

                        pacientes.Add(paciente);

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pacientes;
        }

        public static Paciente GetById(int id)
        {
            Paciente pacientes = new Paciente();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM paciente WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        pacientes.Id = int.Parse(dataReader["id"].ToString());
                        pacientes.Nombre = dataReader["nombre"].ToString();

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pacientes;
        }

        public static bool Verificar(string nombre, string apellido, string nss)
        {
            bool verificado = false;
            
            //List<Paciente> pacientes = new List<Paciente>();
            
            try
            {

                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();


                    //if (id == 0)
                    //{
                        cmd.CommandText = "SELECT * FROM paciente WHERE id = @nombre, apellidos = @apellido, nss = @nss";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@nss", nss);
                    /*}
                    else
                    {
                        cmd.CommandText = "UPDATE estado SET nombre = @nombre WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                    }*/

                    verificado = cmd.ExecuteNonQuery() == 1;

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
            return verificado;
        }

    }
}
