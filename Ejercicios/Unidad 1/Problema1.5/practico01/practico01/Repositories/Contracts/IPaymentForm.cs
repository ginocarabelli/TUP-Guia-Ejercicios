using practico01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Repositories.Contracts
{
    public interface IPaymentForm
    {
        PaymentForm GetPaymentFormById(int id);
    }
}
