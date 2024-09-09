using Problema1y2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1y2.Objetos
{
    public class Pila : ICollection
    {
        // Lo mejor para una Pila es trabajar con Arrays

        private object[] array; // crea un array de objetos
        private int contador; // crea un contador de tipo int

        public Pila(int capacidad)
        {
            array = new object[capacidad]; // asignamos el tamaño del array según el parámetro
            contador = 0; // inicializamos el contador en 0
        }
        public bool añadir(object elemento)
        {
            if (contador >= array.Length) // si el contador es mayor que el tamaño del array
            {
                return false; // retorna falso ya que la pila está llena.
            }
            array[contador] = elemento; // asigna en la posición contador el elemento añadido, ej: si el contador es 0, añade el elemento en la posición 0
            contador++; // aumenta en 1 el contador
            return true; // devuelve true, significa que se agregó el elemento al array
        }
        public bool estaVacia()
        {
            return contador == 0; // si contador == 0, es porque no hay elementos en la lista y retornará true, de lo contrario retornará false
        }
        public object extraer()
        {
            if (estaVacia())
            {
                throw new InvalidOperationException("La pila está vacía.");
            }
            object elemento = array[contador - 1]; // obtiene el último elemento del array, porque contador termina siendo 1 más que el tamaño del array
                                                   // entonces se le resta 1 para que sea el último índice del array
            contador--; // resta 1 al contador para liberar un espacio, ya que si no se resta el contador quedará del mismo tamaño
            return elemento; // devuelve el elemento extraído
        }
        public object primero()
        {
            if (estaVacia())
            {
                throw new InvalidOperationException("La pila está vacía.");
            }
            return array[contador - 1]; // como es una Pila, devuelve el último elemento añadido, es decir el primero en salir
        }
        public int retornarContador()
        {
            return contador; // devuelve la posición del contador
        }
    }
}
