using ProduccionBack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Repositories.Contracts
{
    public interface IBillDetail
    {
        InvoiceDetail GetInvoiceDetailsById(int id);
        bool Save(InvoiceDetail oInvoiceDetail);
        bool Delete(int id);
        bool Update(InvoiceDetail oInvoiceDetail);
        bool Validate(int id);
    }
}
