
using System.Data;
using System.Data.SqlClient;

namespace ProduccionBack.Data
{
    public class DBHelper
    {
        private static DBHelper instancia = null;
        private SqlConnection conexion;
        
        private DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=(localdb)\FacuGino;Initial Catalog=produccion;Integrated Security=True");
        }
        
        public static DBHelper GetInstancia()
        {
            if (instancia == null)
                instancia = new DBHelper();
            return instancia;
        }

        public SqlConnection GetConnection()
        {
            return conexion;
        }


        public DataTable Consultar(string nombreSP, List<SqlParameter>? parameters = null)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            if(parameters != null)
            {
                foreach (var param in parameters)
                    comando.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;   
        }
    }
}
