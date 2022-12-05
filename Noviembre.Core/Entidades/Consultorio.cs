using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    internal class Consultorio
    {
        public int Id { get; set; }
        public int NumeroExterior { get; set; }
        public Doctor Doctor { get; set; }
    }
}
