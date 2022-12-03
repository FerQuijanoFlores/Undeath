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
                    string query = "SELECT id, nombre FROM pciente ORDER BY nombre;";

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


    }
}
