using practico01.Data;
using practico01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Services
{
    public class BillsManager
    {
        ProjectADO pADO;
        public BillsManager()
        {
            pADO = new ProjectADO();
        }
        public List<Invoice> GetAllBills()
        {
            return pADO.GetAll();
        }
        public Invoice GetInvoiceById(int id)
        {
            return pADO.GetInvoiceById(id);
        }
        public Article GetArticleById(int id)
        {
            return pADO.GetArticleById(id);
        }
        public InvoiceDetail GetInvoiceDetailById(int id)
        {
            return pADO.GetInvoiceDetailsById(id);
        }
        public PaymentForm GetPaymentFormById(int id)
        {
            return pADO.GetPaymentFormById(id);
        }
    }
}
