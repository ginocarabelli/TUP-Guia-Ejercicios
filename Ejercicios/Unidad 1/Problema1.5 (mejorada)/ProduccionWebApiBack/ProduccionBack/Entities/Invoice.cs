using ProduccionBack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Domain
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PaymentForm PForm { get; set; }
        public string Client { get; set; }

        private List<InvoiceDetail> Details;

        public List<InvoiceDetail> GetDetails()
        {
            return Details;
        }
        public Invoice()
        {
            Details = new List<InvoiceDetail>();
        }
        public void AddDetail(InvoiceDetail detail)
        {
            if(detail != null)
                Details.Add(detail);
        }
        public void RemoveDetail(int index)
        {
            Details.RemoveAt(index);
        }

        public override string ToString()
        {
            return $"[Nro: {InvoiceId}, Fecha: {InvoiceDate}, Forma de Pago: {PForm.PaymentFormName}, Cliente: {Client}, Cantidad: {Detail.Quantity}]";
        }
    }
}
