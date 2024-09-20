using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Entities
{
    public class Article
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Pre_Unitario { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
