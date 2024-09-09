using Problema1y2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1y2.Objetos
{
    public class Cola : ICollection
    {
        // Lo mejor para una Cola es trabajar con Listas

        private List<object> lista; // crea una lista de objetos

        public Cola()
        {
            lista = new List<object>(); // instancia la lista de objetos vacía
        }

        public bool estaVacia()
        {
            return lista.Count == 0; // si la cantidad de items en lista es 0, retornará true, de lo contrario false
        }

        public object extraer()
        {
            if (estaVacia())
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            object elemento = lista[0]; // guarda en una variable el primer elemento de la lista
            lista.RemoveAt(0); // la función RemoveAt recibe un índice como parámetro, es decir que en este caso, elimina el elemento 0 de lista
            return elemento; // devuelve el elemento previamente almacenado
        }

        public object primero()
        {
            if (estaVacia())
            {
                throw new InvalidOperationException("La cola está vacía.");
            }
            return lista[0]; // devuelve el elemento en la posición 0 de la lista, es decir, el primer elemento de la lista
        }

        public bool añadir(object elemento)
        {
            lista.Add(elemento); // como es una Lista, añade en la última posición un elemento
            return true; // retorna true si se añadió el elemento
        }
    }
}
