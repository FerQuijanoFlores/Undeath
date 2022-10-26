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
    }
}
