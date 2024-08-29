using practico01.Domain;
using practico01.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Services
{
    public class BillsManager
    {
        BillsRepository bRepo;
        public BillsManager()
        {
            bRepo = new BillsRepository();
        }
        public List<Invoice> GetAll()
        {
            return bRepo.GetAll();
        }
        public Invoice GetInvoiceById(int id)
        {
            return bRepo.GetInvoiceById(id);
        }
        public bool Save(Invoice oInvoice)
        {
            return bRepo.Save(oInvoice);
        }
        public bool Update(Invoice oInvoice)
        {
            return bRepo.Update(oInvoice);
        }
        public bool Delete(int id)
        {
            return bRepo.Delete(id);
        }
    }
}
