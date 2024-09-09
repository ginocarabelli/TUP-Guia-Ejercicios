// See https://aka.ms/new-console-template for more information
using Problema3.Interfaces;
using Problema3.Objetos;
namespace Problema3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Probando Programa:");

            Producto[] productos = new Producto[4];

            Producto suelto1 = new Suelto(1, "Coca Cola", 1300.00m, 0.750m);
            Producto suelto2 = new Suelto(2, "Alfajor Rasta", 1500.00m, 0.570m);
            Producto pack1 = new Pack(3, "Sanguche de Miga", 1000.00m, 24);
            Producto pack2 = new Pack(4, "Pebete", 1100.00m, 12);

            productos[0] = suelto1;
            productos[1] = suelto2;
            productos[2] = pack1;
            productos[3] = pack2;

            decimal PrecioTotal = 0;

            Console.WriteLine("\nProductos en el comercio:");

            foreach(var producto in productos)
            {
                Console.WriteLine($"\nCódigo: {producto.Codigo}, Nombre: {producto.Nombre}, Precio: ${producto.CalcularPrecio()}");
                PrecioTotal += producto.CalcularPrecio();
            }
            Console.WriteLine($"\nEl total es de: ${PrecioTotal}");
        }
    }
}