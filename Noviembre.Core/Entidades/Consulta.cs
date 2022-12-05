using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Consultorio Consultorio { get; set; }
        public Doctor Doctor { get; set; }
        public Paciente Paciente { get; set; }

        public static List<Consulta> GetAll()
        {
            List<Consulta> consultas = new List<Consulta>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    
                    string query = "SELECT consul.id, consul.fecha, consul.idConsultorio, consul.idDoctor, consul.idPaciente, con.numeroExterior, doc.nombre AS \"nombreDoc\", doc.apellido AS \"apellidoDoc\", pac.nombre AS \"nombrePaciente\", pac.apellidos AS \"apellidoPaciente\" FROM cita consul INNER JOIN doctor doc INNER JOIN consultorio con INNER JOIN paciente pac ON consul.idDoctor = doc.id AND consul.idPaciente = pac.id AND consul.idConsultorio = con.id;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Doctor doctor = new Doctor();
                        Paciente paciente = new Paciente();
                        Consultorio consultorio = new Consultorio();
                        Consulta consulta = new Consulta();
                        consulta.Id = int.Parse(dataReader["id"].ToString());
                        consulta.Fecha = DateTime.Parse(dataReader["fecha"].ToString());
                        doctor.Nombre = dataReader["nombreDoc"].ToString();
                        doctor.Apellido = dataReader["apellidoDoc"].ToString();
                        paciente.Nombre = dataReader["nombrePaciente"].ToString();
                        paciente.apellido = dataReader["apellidoPaciente"].ToString();
                        consultorio.NumeroExterior = int.Parse(dataReader["numeroExterior"].ToString());

                        //consulta = int.Parse(dataReader["numeroExterior"].ToString());


                        consulta.Doctor = doctor;
                        consulta.Paciente = paciente;
                        consulta.Consultorio = consultorio;
                        consultas.Add(consulta);

                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return consultas;
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
                    cmd.CommandText = "DELETE FROM cita WHERE id = @id";
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
