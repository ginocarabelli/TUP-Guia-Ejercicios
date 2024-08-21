using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1y2.Interfaces
{
    public interface ICollection
    {
        bool añadir(object elemento);
        bool estaVacia();
        object extraer();
        object primero();
    }
}
