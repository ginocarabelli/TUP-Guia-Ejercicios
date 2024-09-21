using ProduccionBack.Domain;
using ProduccionBack.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public class PaymentFormsManager
    {
        PaymentFormRepository pfRepo;
        public PaymentFormsManager()
        {
            pfRepo = new PaymentFormRepository();
        }
        public PaymentForm GetPaymentFormById(int id)
        {
            return pfRepo.GetPaymentFormById(id);
        }
    }
}
