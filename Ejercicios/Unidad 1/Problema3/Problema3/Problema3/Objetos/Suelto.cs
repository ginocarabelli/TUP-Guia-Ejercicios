using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema3.Objetos
{
    public class Suelto : Producto
    {
        public decimal Medida { get; set; }

        public Suelto(int codigo, string nombre, decimal precio, decimal medida) : base(codigo, nombre, precio)
        {
            Medida = medida;
        }
        public override decimal CalcularPrecio()
        {
            return Medida * Precio;
        }

    }
}
