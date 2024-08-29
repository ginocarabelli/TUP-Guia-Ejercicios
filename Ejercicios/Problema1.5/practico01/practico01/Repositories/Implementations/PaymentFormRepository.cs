using practico01.Domain;
using practico01.Repositories.Contracts;
using practico01.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Repositories.Implementations
{
    public class PaymentFormRepository : IPaymentForm
    {
        public PaymentForm GetPaymentFormById(int id)
        {
            PaymentForm oPaymentForm = new PaymentForm();
            var helper = DataHelper.GetInstance();
            DataTable table = helper.ExecuteSPQuery("SP_GetPaymentFormById", new SqlParameter("@ID", id));
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                int paymentFormId = Convert.ToInt32(row["payment_form_id"]);
                string paymentFormName = Convert.ToString(row["payment_form"]);

                oPaymentForm.PaymentFormId = paymentFormId;
                oPaymentForm.PaymentFormName = paymentFormName;
            }
            return oPaymentForm;
        }
    }
}
