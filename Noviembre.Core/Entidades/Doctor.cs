using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RFC { get; set; }
        public string CedulaProfecional { get; set; }
        public string Email { get; set; }
        public string Especialidad { get; set; }

        public static List<Doctor> GetAll()
        {
            List<Doctor> Doctores = new List<Doctor>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM doctor ORDER BY nombre;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Doctor doctor = new Doctor();
                        doctor.Id = int.Parse(dataReader["id"].ToString());
                        doctor.Nombre = dataReader["nombre"].ToString();

                        Doctores.Add(doctor);

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Doctores;
        }

        public static Doctor GetById(int id)
        {
            Doctor doctor = new Doctor();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, apellido, especialidad FROM doctor WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        doctor.Id = int.Parse(dataReader["id"].ToString());
                        doctor.Nombre = dataReader["nombre"].ToString();
                        doctor.Apellido = dataReader["apellido"].ToString();
                        doctor.Especialidad = dataReader["especialidad"].ToString();

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return doctor;
        }

        public static bool Guardar(int id, string nombre, string apellido, string RFC, string cedulaProfecional, string email, string especialidad)
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
                        cmd.CommandText = "INSERT INTO doctor (nombre, apellido, rfc, cedulaProfecional, email, especialidad) VALUES (@nombre, @apellido, @rfc, @cedulaProfecional, @email, @especialidad)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@rfc", RFC);
                        cmd.Parameters.AddWithValue("@cedulaProfecional", cedulaProfecional);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@especialidad", especialidad);
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
