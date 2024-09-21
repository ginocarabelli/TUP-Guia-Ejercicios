using ProduccionBack.Domain;
using ProduccionBack.Repositories.Contracts;
using ProduccionBack.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Repositories.Implementations
{
    public class BillsRepository : IBillsRepository
    {
        PaymentFormRepository pfRepo;
        InvoiceDetailRepository ivRepo;

        public BillsRepository()
        {
            pfRepo = new PaymentFormRepository();
            ivRepo = new InvoiceDetailRepository();
        }

        public List<Invoice> GetAll()
        {
            List<Invoice> lst = new List<Invoice>();
            Invoice? oInvoice = null;
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetAll");
            foreach (DataRow row in t.Rows)
            {
                if(oInvoice == null || oInvoice.InvoiceId != Convert.ToInt32(row["INVOICE_ID"]))
                {
                    oInvoice = new Invoice();
                    oInvoice.InvoiceId = Convert.ToInt32(row["INVOICE_ID"]);
                    oInvoice.PForm = pfRepo.ReadPaymentForm(row);
                    oInvoice.AddDetail(ivRepo.ReadDetail(row));
                }
                lst.Add(oInvoice);
            }
            return lst;
        }
        public Invoice GetInvoiceById(int id)
        {
            Invoice oInvoice = new Invoice();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetInvoiceById", new SqlParameter("@ID", id));
            if (t.Rows.Count > 0)
            {
                DataRow row = t.Rows[0];

                int invoiceId = Convert.ToInt32(row["INVOICE_ID"]);
                DateTime date = Convert.ToDateTime(row["INVOICE_DATE"]);
                string client = Convert.ToString(row["CLIENT"]);

                oInvoice.InvoiceId = invoiceId;
                oInvoice.InvoiceDate = date;
                oInvoice.PForm = pfRepo.ReadPaymentForm(row);
                oInvoice.AddDetail(ivRepo.ReadDetail(row));
                oInvoice.Client = client;
            }
            return oInvoice;
        }
        public bool Validate(int id)
        {
            var helper = DataHelper.GetInstance();
            DataTable table = helper.ExecuteSPQuery("SP_GetInvoiceById", new SqlParameter("@ID", id));
            if(table.Rows.Count > 0)
            {
                Console.WriteLine("El código de esta factura ya existe, ingrese otro");
                return true;
            }
            return false;
        }
        public bool Save(Invoice oInvoice)
        {
            bool result = false;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                if (!Validate(oInvoice.InvoiceId))
                {
                    var helper = DataHelper.GetInstance();


                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@ID", oInvoice.InvoiceId),
                        new SqlParameter("@INVOICE_DATE", oInvoice.InvoiceDate),
                        new SqlParameter("@PAYMENT_FORM_ID", oInvoice.PForm.PaymentFormId),
                        new SqlParameter("@INVOICE_DETAIL_ID", oInvoice.Detail.InvoiceDetailsID),
                        new SqlParameter("@CLIENT", oInvoice.Client)
                    };
                    result = helper.ExecuteCrudSPQuery("SP_SaveInvoice", parameters);
                }
            }
            return result;
        }

        public bool Update(Invoice oInvoice)
        {
            var helper = DataHelper.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", oInvoice.InvoiceId),
                new SqlParameter("@INVOICE_DATE", oInvoice.InvoiceDate),
                new SqlParameter("@PAYMENT_FORM_ID", oInvoice.PForm.PaymentFormId),
                new SqlParameter("@INVOICE_DETAIL_ID", oInvoice.Detail.InvoiceDetailsID),
                new SqlParameter("@CLIENT", oInvoice.Client)
            };
            bool result = helper.ExecuteCrudSPQuery("SP_UpdateInvoice", parameters);
            return result;
        }
        public bool Delete(int id)
        {
            var helper = DataHelper.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", id),
            };
            bool result = helper.ExecuteCrudSPQuery("SP_DeleteInvoice", parameters);
            return result;
        }

    }
}
