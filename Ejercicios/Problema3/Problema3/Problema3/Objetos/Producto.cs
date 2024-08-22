using Problema3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema3.Objetos
{
    public abstract class Producto : IPrecio
    {
        private object[] array;
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(int codigo, string nombre, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }
        public abstract decimal CalcularPrecio();
    }
}
