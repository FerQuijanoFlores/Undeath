using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Estado Estado { get; set; }

        public static List<Municipio> GetAll()
        {
            List<Municipio> municipios = new List<Municipio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    //SELECT mu.id, mu.nombre, es.id, es.nombre FROM municipio mu INNER JOIN estado es ON mu.idEstado = es.id
                    string query = "SELECT mu.id, mu.nombre, es.id AS \"idEstado\", es.nombre AS \"nombreEstado\" FROM municipio mu INNER JOIN estado es ON mu.idEstado = es.id;";

                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["id"].ToString());
                        municipio.Nombre = dataReader["nombre"].ToString();

                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["idEstado"].ToString());
                        estado.Nombre = dataReader["nombreEstado"].ToString();

                        municipio.Estado = estado;
                        municipios.Add(municipio);

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return municipios;
        }

    }
}
