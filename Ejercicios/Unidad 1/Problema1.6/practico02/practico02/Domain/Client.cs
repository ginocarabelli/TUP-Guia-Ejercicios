using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico02.Domain
{
    public class Client
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public Account Cuenta { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
