using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Domain
{
    public class FormaDePago
    {
        public int IdFormaPago { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
