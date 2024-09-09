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
    public class InvoiceDetailRepository : IBillDetail
    {
        public InvoiceDetail GetInvoiceDetailsById(int id)
        {
            InvoiceDetail oInvoiceDetail = new InvoiceDetail();
            var helper = DataHelper.GetInstance();
            DataTable table = helper.ExecuteSPQuery("SP_GetInvoiceDetailsById", new SqlParameter("@ID", id));
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                int invoiceDetailId = Convert.ToInt32(row["INVOICE_DETAILS_ID"]);
                Article article = new Article()
                {
                    ArticleID = Convert.ToInt32(row["ARTICLE_ID"]),
                    ArticleName = row["ARTICLE_NAME"].ToString(),
                    UnitPrice = Convert.ToInt32(row["UNIT_PRICE"])
                };
                int quantity = Convert.ToInt32(row["QUANTITY"]);

                oInvoiceDetail.InvoiceDetailsID = invoiceDetailId;
                oInvoiceDetail.Article = article;
                oInvoiceDetail.Quantity = quantity;
            }
            return oInvoiceDetail;
        }
        public bool Validate(int id)
        {
            var helper = DataHelper.GetInstance();
            DataTable table = helper.ExecuteSPQuery("SP_GetInvoiceDetailsById", new SqlParameter("@ID", id));
            if (table.Rows.Count > 0)
            {
                Console.WriteLine("El código de este detalle factura ya existe, ingrese otro");
                return true;
            }
            return false;
        }
        public bool Save(InvoiceDetail oInvoiceDetail)
        {
            bool result = false;
            if (!Validate(oInvoiceDetail.InvoiceDetailsID))
            {
                var helper = DataHelper.GetInstance();
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@ID", oInvoiceDetail.InvoiceDetailsID),
                new SqlParameter("@ARTICLE_ID", oInvoiceDetail.Article.ArticleID),
                new SqlParameter("@QUANTITY", oInvoiceDetail.Quantity)
                };
                result = helper.ExecuteCrudSPQuery("SP_CreateInvoiceDetails", parameters);
            }
            return result;
        }
        public bool Update(InvoiceDetail oInvoiceDetail)
        {
            var helper = DataHelper.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", oInvoiceDetail.InvoiceDetailsID),
                new SqlParameter("@ARTICLE_ID", oInvoiceDetail.Article.ArticleID),
                new SqlParameter("@QUANTITY", oInvoiceDetail.Quantity)
            };
            bool result = helper.ExecuteCrudSPQuery("SP_UpdateInvoiceDetails", parameters);
            return result;
        }
        public bool Delete(int id)
        {
            var helper = DataHelper.GetInstance();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", id),
            };
            bool result = helper.ExecuteCrudSPQuery("SP_DeleteInvoiceDetails", parameters);
            return result;
        }

    }
}
