using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Domain
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentForm PForm { get; set; }
        public InvoiceDetail Detail { get; set; }
        public string Client { get; set; }

        public override string ToString()
        {
            return $"[Nro: {InvoiceId}, Fecha: {InvoiceDate}, Forma de Pago: {PForm.PaymentFormName}, Cliente: {Client}, Cantidad: {Detail.Quantity}]";
        }
    }
}
