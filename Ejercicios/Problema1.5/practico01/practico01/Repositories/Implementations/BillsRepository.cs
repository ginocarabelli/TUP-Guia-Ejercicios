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
    public class BillsRepository : IBillsRepository
    {
        public List<Invoice> GetAll()
        {
            List<Invoice> lst = new List<Invoice>();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetAll");
            foreach (DataRow row in t.Rows)
            {
                int invoiceId = Convert.ToInt32(row["INVOICE_ID"]);
                DateTime date = Convert.ToDateTime(row["INVOICE_DATE"]);
                PaymentForm paymentForm = new PaymentForm()
                {
                    PaymentFormId = Convert.ToInt32(row["PAYMENT_FORM_ID"]),
                    PaymentFormName = row["PAYMENT_FORM_NAME"].ToString()
                };
                InvoiceDetail invoiceDetail = new InvoiceDetail()
                {
                    InvoiceDetailsID = Convert.ToInt32(row["INVOICE_DETAILS_ID"]),
                    Article = new Article()
                    {
                        ArticleID = Convert.ToInt32(row["ARTICLE_ID"]),
                        ArticleName = row["ARTICLE_NAME"].ToString(),
                        UnitPrice = Convert.ToInt32(row["UNIT_PRICE"])
                    },
                    Quantity = Convert.ToInt32(row["QUANTITY"])
                };
                string client = Convert.ToString(row["CLIENT"]);

                Invoice oInvoice = new Invoice()
                {
                    InvoiceId = invoiceId,
                    InvoiceDate = date,
                    PForm = paymentForm,
                    Detail = invoiceDetail,
                    Client = client
                };
                lst.Add(oInvoice);
            }
            return lst;
        }
        public Invoice GetInvoiceById(int id)
        {
            Invoice oInvoice = new Invoice();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetById", new SqlParameter("@ID", id));
            if (t.Rows.Count > 0)
            {
                DataRow row = t.Rows[0];

                int invoiceId = Convert.ToInt32(row["INVOICE_ID"]);
                DateTime date = Convert.ToDateTime(row["INVOICE_DATE"]);
                PaymentForm paymentForm = new PaymentForm()
                {
                    PaymentFormId = Convert.ToInt32(row["PAYMENT_FORM_ID"]),
                    PaymentFormName = row["PAYMENT_FORM_NAME"].ToString()
                };
                InvoiceDetail invoiceDetail = new InvoiceDetail()
                {
                    InvoiceDetailsID = Convert.ToInt32(row["INVOICE_DETAILS_ID"]),
                    Article = new Article()
                    {
                        ArticleID = Convert.ToInt32(row["ARTICLE_ID"]),
                        ArticleName = row["ARTICLE_NAME"].ToString(),
                        UnitPrice = Convert.ToInt32(row["UNIT_PRICE"])
                    },
                    Quantity = Convert.ToInt32(row["QUANTITY"])
                };
                string client = Convert.ToString(row["CLIENT"]);

                oInvoice.InvoiceId = invoiceId;
                oInvoice.InvoiceDate = date;
                oInvoice.PForm = paymentForm;
                oInvoice.Detail = invoiceDetail;
                oInvoice.Client = client;
            }
            return oInvoice;
        }
        public bool Save(Invoice oFactura)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
