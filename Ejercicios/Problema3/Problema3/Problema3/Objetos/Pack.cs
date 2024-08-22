using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema3.Objetos
{
    public class Pack : Producto
    {
        public int Cantidad { get; set; }

        public Pack(int codigo, string nombre, decimal precio, int cantidad) : base(codigo, nombre, precio)
        {
            Cantidad = cantidad;
        }
        public override decimal CalcularPrecio()
        {
            return Cantidad * Precio;
        }
    }
}
