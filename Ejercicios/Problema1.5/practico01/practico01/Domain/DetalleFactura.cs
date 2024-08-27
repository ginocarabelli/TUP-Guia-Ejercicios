using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Domain
{
    public class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public Article Article { get; set; }
        public int Cantidad { get; set; }
    }
}
