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
                    string query = "SELECT id, nombre, apellidos, nss, curp, email FROM paciente ORDER BY nombre;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Paciente paciente = new Paciente();
                        paciente.Id = int.Parse(dataReader["id"].ToString());
                        paciente.Nombre = dataReader["nombre"].ToString();
                        paciente.apellido = dataReader["apellidos"].ToString();
                        paciente.nss = dataReader["nss"].ToString();
                        paciente.curp = dataReader["curp"].ToString();
                        paciente.email = dataReader["email"].ToString();

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
            Paciente paciente = new Paciente();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, apellidos, nss, curp, email FROM paciente WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        paciente.Id = int.Parse(dataReader["id"].ToString());
                        paciente.Nombre = dataReader["nombre"].ToString();
                        paciente.apellido = dataReader["apellidos"].ToString();
                        paciente.nss = dataReader["nss"].ToString();
                        paciente.curp = dataReader["curp"].ToString();
                        paciente.email = dataReader["email"].ToString();

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return paciente;
        }


        public static bool Guardar(int id, string nombre, string apellido, string nss, string curp, string email)
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
                        cmd.CommandText = "INSERT INTO paciente (nombre, apellidos, nss, curp, email) VALUES (@nombre, @apellido, @nss, @curp, @email)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@nss", nss);
                        cmd.Parameters.AddWithValue("@curp", curp);
                        cmd.Parameters.AddWithValue("@email", email);
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE paciente SET nombre = @nombre, apellidos = @apellido, nss = @nss, curp = @curp, email = @email WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@nss", nss);
                        cmd.Parameters.AddWithValue("@curp", curp);
                        cmd.Parameters.AddWithValue("@email", email);
                    }
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    

    public static bool Eliminar(int id)
    {
        bool result = false;
        try
        {
            Conexion conexion = new Conexion();
            if (conexion.OpenConnection())
            {
                MySqlCommand cmd = conexion.connection.CreateCommand();
                cmd.CommandText = "DELETE FROM paciente WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", id);
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
