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
            finally
            {
                _connection.Close();
            }
            return t;
        }
        public int ExecuteCrudSPQuery(string sp, params SqlParameter[] parameters)
        {
            int affectedRows = 0;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                affectedRows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"\nSQL Error: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return affectedRows;
        }
    }
}
