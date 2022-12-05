using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Consultorio
    {
        public int Id { get; set; }
        public int NumeroExterior { get; set; }
        public Doctor Doctor { get; set; }

        public static List<Consultorio> GetAll()
        {
            List<Consultorio> consultorios = new List<Consultorio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    Doctor doctor = new Doctor();
                   
                    string query = "SELECT con.id, con.numeroExterior, con.idDoctor, doc.id AS \"idDoc\", doc.nombre, doc.apellido, doc.especialidad FROM consultorio con INNER JOIN doctor doc ON con.idDoctor = doc.id;";
                   

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    

                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Consultorio consultorio = new Consultorio();
                        consultorio.Id = int.Parse(dataReader["id"].ToString());
                        consultorio.NumeroExterior = int.Parse(dataReader["numeroExterior"].ToString());
                        doctor.Id = int.Parse(dataReader["idDoc"].ToString());
                        doctor.Nombre = dataReader["nombre"].ToString();
                        doctor.Apellido = dataReader["apellido"].ToString();
                        doctor.Especialidad = dataReader["especialidad"].ToString();


                        consultorio.Doctor = doctor;
                        consultorios.Add(consultorio);

                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return consultorios;
        }

        public static bool Guardar(int id, int numeroExterior, int idDoctor)
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
                        cmd.CommandText = "INSERT INTO consultorio (numeroExterior, idDoctor) VALUES (@numeroExterior, @idDoctor);";
                        cmd.Parameters.AddWithValue("@numeroExterior", numeroExterior);
                        cmd.Parameters.AddWithValue("@idDoctor", idDoctor);
                        
                    }
                    else
                    {
                        //ahorita
                        cmd.CommandText = "UPDATE consultorio SET numeroExterior = @numeroExterior, idDoctor = @idDoctor WHERE id = @id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@numeroExterior", numeroExterior);
                        cmd.Parameters.AddWithValue("@idDoctor", idDoctor);
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
        public static Consultorio GetById(int id)
        {
            Consultorio consultorio = new Consultorio();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, numeroExterior, idDoctor FROM consultorio WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    Doctor doctor = new Doctor();

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        consultorio.Id = int.Parse(dataReader["id"].ToString());
                        consultorio.NumeroExterior = int.Parse(dataReader["numeroExterior"].ToString());

                        doctor.Id = int.Parse(dataReader["numeroExterior"].ToString());

                        consultorio.Doctor = doctor;


                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return consultorio;
        }
    }
}
