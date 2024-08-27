using practico01.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace practico01.Data
{
    public class ProjectADO : IProject
    {
        private SqlConnection _connection;

        public ProjectADO()
        {
            _connection = new SqlConnection(Properties.Resources.ConnectionString);
        }
        public double CalcularPrecio()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAll()
        {
            List<Article> lst = new List<Article>();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetAll");
            foreach(DataRow row in t.Rows)
            {
                int codigo = Convert.ToInt32(row["codigo"]);
                string nombre = Convert.ToString(row["nombre"]);
                double precioUnitario = Convert.ToDouble(row["precioUnitario"]);

                Article oArticle = new Article()
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    PrecioUnitario = precioUnitario
                };
                lst.Add(oArticle);
            }
            return lst;
        }
        public Article GetArticleById(int id)
        {
            Article oArticle = new Article();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetArticleById", new SqlParameter("@codigo", id));
            if (t.Rows.Count > 0)
            {
                DataRow row = t.Rows[0];

                int codigo = Convert.ToInt32(row["codigo"]);
                string nombre = Convert.ToString(row["nombre"]);
                double precioUnitario = Convert.ToDouble(row["precioUnitario"]);

                oArticle.Codigo = codigo;
                oArticle.Nombre = nombre;
                oArticle.PrecioUnitario = precioUnitario;
            }
            return oArticle;
        }
        public DetalleFactura GetDFById(int id)
        {
            DetalleFactura oDF = new DetalleFactura();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetDFById", new SqlParameter("@codigo", id));
            if (t.Rows.Count > 0)
            {
                DataRow row = t.Rows[0];

                int codigo = Convert.ToInt32(row["idDetallesFacturas"]);
                Article article = GetArticleById((int)row["codigo"]);
                int cantidad = Convert.ToInt32(row["cantidad"]);

                oDF.IdDetalleFactura = codigo;
                oDF.Article = article;
                oDF.Cantidad = cantidad;
            }
            return oDF;
        }
        public FormaDePago GetFPById(int id)
        {
            FormaDePago oFP = new FormaDePago();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetFPById", new SqlParameter("@codigo", id));
            if (t.Rows.Count > 0)
            {
                DataRow row = t.Rows[0];

                int codigo = Convert.ToInt32(row["idFormaPago"]);
                string nombre = Convert.ToString(row["nombre"]);

                oFP.IdFormaPago = codigo;
                oFP.Nombre = nombre;
            }
            return oFP;
        }
        public Factura GetFacturaById(int id)
        {
            Factura oFactura = new Factura();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetById", new SqlParameter("@codigo", id));
            if(t.Rows.Count > 0)
            {
                DataRow row = t.Rows[0];

                int codigo = Convert.ToInt32(row["codigo"]);
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                FormaDePago formaPago = GetFPById((int)row["idFormaPago"]);
                DetalleFactura detalleFactura = GetDFById((int)row["idDetallesFacturas"]);
                string cliente = Convert.ToString(row["cliente"]);

                oFactura.NroFactura = codigo;
                oFactura.Fecha = fecha;
                oFactura.FormaPago = formaPago;
                oFactura.Detalle = detalleFactura;
                oFactura.Cliente = cliente;
            }
            return oFactura;
        }

        public bool Save(Factura oFactura)
        {
            return true;
            //var helper = DataHelper.GetInstance();
            //bool result = helper.ExecuteCrudSPQuery("SP_SaveProduct", )
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
