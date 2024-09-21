using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Domain
{
    public class PaymentForm
    {
        public int PaymentFormId { get; set; }
        public string PaymentFormName { get; set; }

        public override string ToString()
        {
            return PaymentFormName;
        }
    }
}
