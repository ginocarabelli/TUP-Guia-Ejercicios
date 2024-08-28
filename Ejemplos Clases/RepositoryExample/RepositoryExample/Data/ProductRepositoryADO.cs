using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    public class ProductRepositoryADO : IProductRepository
    {
        private SqlConnection _connection;

        public ProductRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> lst = new List<Product>();
            var helper = DataHelper.GetInstance();
            DataTable t = helper.ExecuteSPQuery("SP_GetAll");
            foreach(DataRow row in t.Rows)
            {
                int codigo = Convert.ToInt32(row["codigo"]);
                string nombre = Convert.ToString(row["n_producto"]);
                int stock = Convert.ToInt32(row["stock"]);
                bool activo = Convert.ToBoolean(row["activo"]);

                Product oProduct = new Product()
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Stock = stock,
                    Activo = activo
                };
                lst.Add(oProduct);
            }
            return lst;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Product oProduct)
        {
            bool result = true;
            string query = "SP_Save";
            try
            {
                if(oProduct != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", oProduct.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", oProduct.Nombre);
                    cmd.Parameters.AddWithValue("@stock", oProduct.Stock);
                    result = cmd.ExecuteNonQuery() == 1; // cantidad de filas afectadas
                }
                
            }
            catch (SqlException sqlExc)
            {
            }
            finally
            {
                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
