using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico02.Data
{
    public class DataHelper
    {
        // acceso a BD
        // patron singleton
        // constructor privado
        // atributo estatico

        private SqlConnection _connection;
        private static DataHelper _instancia;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.cnnStrin);
        }
        public static DataHelper GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new DataHelper();
            }
            return _instancia;
        }
        public DataTable ExecuteSPQuery(string sp, params SqlParameter[] parameters)
        {
            DataTable t = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                t.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (SqlException)
            {
                t = null;
            }
            return t;
        }
        public bool ExecuteCrudSPQuery(string sp, params SqlParameter[] parameters)
        {
            bool x = false;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    x = true;
                }
                _connection.Close();
            }
            catch (SqlException)
            {
                x = false;
            }
            return x;
        }
    }
}
