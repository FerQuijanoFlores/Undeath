using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    internal class Consulta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Consultorio Consultorio { get; set; }
        public Doctor Doctor { get; set; }
        public Paciente Paciente { get; set; }
        
    }
}
