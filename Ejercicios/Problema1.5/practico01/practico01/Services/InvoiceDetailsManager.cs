using practico01.Domain;
using practico01.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Services
{
    public class InvoiceDetailsManager
    {
        InvoiceDetailRepository bdRepo;
        public InvoiceDetailsManager()
        {
            bdRepo = new InvoiceDetailRepository();
        }
        public InvoiceDetail GetInvoiceDetailById(int id)
        {
            return bdRepo.GetInvoiceDetailsById(id);
        }
    }
}
