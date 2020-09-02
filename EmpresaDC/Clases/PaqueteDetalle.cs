using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportacionesDC.Clases
{
    public class PaqueteDetalle
    {
        public int Codigo { get; set; }
        public float Peso { get; set; }
        public int Casillero { get; set; }
        public string Cliente { get; set; }
        public string Estado { get; set; }
    }
}
