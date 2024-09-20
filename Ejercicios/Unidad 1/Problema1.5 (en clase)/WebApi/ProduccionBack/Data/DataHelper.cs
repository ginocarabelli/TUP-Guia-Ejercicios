using System.Data;
using System.Data.SqlClient;

namespace ProduccionBack.Data
{
    public class DataHelper
    {
        private SqlConnection _connection;
        private static DataHelper instance;

        public DataHelper()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\FacuGino;Initial Catalog=Billing;Integrated Security=True");
        }

        public static DataHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new DataHelper();
            }
            return instance;
        }

        public DataTable ExecuteSPQuery(string sp, params SqlParameter[]? parameters)
        {
            DataTable t = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if(parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                t.Load(cmd.ExecuteReader());
            }
            catch (SqlException) 
            {
                t = null;
            }
            return t;
        }
        public bool ExecuteCRUDSPQuery(string sp, params SqlParameter[]? parameters)
        {
            bool x = false;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                if(cmd.ExecuteNonQuery() != 0)
                {
                    x = true;
                }
            }
            catch (SqlException)
            {
                x = false;
            }
            return x;
        }
    }
}
