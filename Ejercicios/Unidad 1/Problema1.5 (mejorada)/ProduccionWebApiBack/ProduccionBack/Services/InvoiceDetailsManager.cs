using ProduccionBack.Domain;
using ProduccionBack.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public class InvoiceDetailsManager
    {
        InvoiceDetailRepository idRepo;
        public InvoiceDetailsManager()
        {
            idRepo = new InvoiceDetailRepository();
        }
        public InvoiceDetail GetInvoiceDetailById(int id)
        {
            return idRepo.GetInvoiceDetailsById(id);
        }
        public bool Save(InvoiceDetail oInvoiceDetail)
        {
            return idRepo.Save(oInvoiceDetail);
        }
        public bool Update(InvoiceDetail oInvoiceDetail)
        {
            return idRepo.Update(oInvoiceDetail);
        }
        public bool Delete(int id)
        {
            return idRepo.Delete(id);
        }
    }
}
