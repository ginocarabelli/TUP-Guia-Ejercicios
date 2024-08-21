// See https://aka.ms/new-console-template for more information
using Problema1y2.Objetos;
using System.Drawing;

namespace Problema1y2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CABE DESTACAR QUE CON PILA NOS REFERIMOS AL INFINITIVO DE APILAR, COMO UNA PILA DE ROPA, LO ÚLTIMO EN ENTRAR ES LO PRIMERO EN SALIR (LIFO)
            // LO CONTRARIO DE UNA COLA, LO PRIMERO EN ENTRAR ES LO PRIMERO EN SALIR (FIFO)
            Console.WriteLine("Probando Pila:");
            Pila pila = new Pila(3);
            pila.añadir("A"); // contador pasa a ser 1
            pila.añadir("B"); // contador pasa a ser 2
            pila.añadir("C"); // contador pasa a ser 3

            Console.WriteLine($"Primero en la pila: {pila.primero()}"); // Debería ser "C", porque fue el último en ser ingresado a la pila
            while (!pila.estaVacia())
            {
                Console.WriteLine($"{pila.retornarContador()}"); // Retorna la posición del contador
                Console.WriteLine($"Extrayendo: {pila.extraer()}"); // Debería extraer siempre el último elemento
            }



            Console.WriteLine("\nProbando Cola:");
            Cola cola = new Cola();
            cola.añadir("1");
            cola.añadir("2");
            cola.añadir("3");

            Console.WriteLine($"Primero en la cola: {cola.primero()}"); // Debería ser "1", porque fue el primero en ser ingresado a la cola

            while (!cola.estaVacia())
            {
                Console.WriteLine($"Extrayendo: {cola.extraer()}"); // Debería extraer siempre el primer elemento
            }
        }
    }

}
