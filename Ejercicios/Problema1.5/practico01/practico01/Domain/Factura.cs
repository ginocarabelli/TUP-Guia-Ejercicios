using practico01.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Domain
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public FormaDePago FormaPago { get; set; }
        public DetalleFactura Detalle { get; set; }
        public string Cliente { get; set; }

        public override string ToString()
        {
            return $"[Nro: {NroFactura}, Fecha: {Fecha}, Forma de Pago: {FormaPago.Nombre}, Cliente: {Cliente}, Cantidad: {Detalle.Cantidad}]";
        }
    }
}
