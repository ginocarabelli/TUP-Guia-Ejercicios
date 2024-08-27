using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Domain
{
    public class Article
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }

        public override string ToString()
        {
            return $"[{Codigo}, {Nombre}, {PrecioUnitario}]";
        }
    }
}
