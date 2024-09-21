using ProduccionBack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Repositories.Contracts
{
    public interface IPaymentForm
    {
        PaymentForm GetPaymentFormById(int id);
    }
}
