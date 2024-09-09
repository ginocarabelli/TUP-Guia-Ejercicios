using RepositoryExample.Data.Utils;
using RepositoryExample.Domain;
using System.Data;
using System.Data.SqlClient;


namespace RepositoryExample.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        public List<Budget> GetAll()
        {
            List<Budget> lst = new List<Budget>();
            Budget? oBudget = null;
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_RECUPERAR_PRESUPUESTOS", null);
            foreach (DataRow row in t.Rows)
            {
                //leer la primer fila y tomar datos del maestro y primer detalle
                if (oBudget == null || oBudget.Id != Convert.ToUInt32(row["id"].ToString()))
                {

                    oBudget = new Budget();
                    oBudget.Client = row["cliente"].ToString();
                    oBudget.Date = Convert.ToDateTime(row["fecha"].ToString());
                    oBudget.Expiration = Convert.ToInt32(row["vigencia"].ToString());
                    oBudget.Id = Convert.ToInt32(row["id"].ToString());
                    oBudget.AddDetail(ReadDetail(row));
                    lst.Add(oBudget);
                }
                else
                {
                    //mientras no cambia el Id del maestro, leer datos de detalles.
                    oBudget.AddDetail(ReadDetail(row));
                }
            }
            return lst;
        }

        //función auxiliar para leer un detalle.
        private DetailBudget ReadDetail(DataRow row)
        {
            DetailBudget detail = new DetailBudget();
            detail.Product = new Product
            {
                Codigo = Convert.ToInt32(row["codigo"].ToString()),
                Nombre = row["n_producto"].ToString(),
                Stock = Convert.ToInt32(row["stock"].ToString()),
                Activo = Convert.ToBoolean(row["esta_activo"].ToString())
            };
            detail.Price = Convert.ToSingle(row["precio"].ToString());
            detail.Count = Convert.ToInt32(row["cantidad"].ToString());
            return detail;
        }

        public Budget? GetById(int id)
        {
            Budget? oBudget = null;
            var helper = DataHelper.GetInstance();
            var parameter = new ParameterSQL("@id", id);
            var parameters = new List<ParameterSQL>();
            parameters.Add(parameter);

            var t = helper.ExecuteSPQuery("SP_RECUPERAR_PRESUPUESTO_POR_ID", parameters);
            foreach (DataRow row in t.Rows)
            {
                if (oBudget == null)
                {
                    oBudget = new Budget();
                    oBudget.Client = row["cliente"].ToString();
                    oBudget.Date = Convert.ToDateTime(row["fecha"].ToString());
                    oBudget.Expiration = Convert.ToInt32(row["vigencia"].ToString());
                    oBudget.Id = Convert.ToInt32(row["id"].ToString());
                    oBudget.AddDetail(ReadDetail(row));
                }
                else
                {
                    oBudget.AddDetail(ReadDetail(row));
                }
            }
            return oBudget;

        }

        public bool Save(Budget oBudget)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                //parámetro de entrada:
                cmd.Parameters.AddWithValue("@cliente", oBudget.Client);
                cmd.Parameters.AddWithValue("@vigencia", oBudget.Expiration);
                //parámetro de salida:
                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int budgetId = (int)param.Value;

                int nroDetail = 1;
                foreach (var detail in oBudget.GetDetails())
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@presupuesto", budgetId);
                    cmdDetail.Parameters.AddWithValue("@id_detalle", nroDetail);
                    cmdDetail.Parameters.AddWithValue("@producto", detail.Product.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Count);
                    cmdDetail.Parameters.AddWithValue("@precio", detail.Price);
                    cmdDetail.ExecuteNonQuery();
                    nroDetail++;
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
