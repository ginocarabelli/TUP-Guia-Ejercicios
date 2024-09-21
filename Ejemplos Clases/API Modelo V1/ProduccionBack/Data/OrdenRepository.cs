

using ProduccionBack.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ProduccionBack.Data
{
    public class OrdenRepository : IOrdenRepository
    {
     
        public bool CrearOrden(OrdenProduccion orden)
        {
            bool aux = true;
            SqlConnection conexion = DBHelper.GetInstancia().GetConnection();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_MAESTRO", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p = new SqlParameter("@nro_orden", SqlDbType.Int);
                p.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(p);
                cmd.Parameters.AddWithValue("@fecha", orden.Fecha);
                cmd.Parameters.AddWithValue("@modelo", orden.Modelo);
                cmd.Parameters.AddWithValue("@estado", orden.Estado);
                cmd.Parameters.AddWithValue("@cantidad", orden.Cantidad);
                cmd.ExecuteNonQuery();

                int nroOrden = (int)p.Value;

                foreach (DetalleOrden det in orden.ListaDetalles)
                {
                    SqlCommand cmd2 = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@nro_orden", nroOrden);
                    cmd2.Parameters.AddWithValue("@id", det.Id);
                    cmd2.Parameters.AddWithValue("@componente", det.Componente.Codigo);
                    cmd2.Parameters.AddWithValue("@cantidad", det.Cantidad);
                    cmd2.ExecuteNonQuery();

                }
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    aux = false;
                    t.Rollback();
                }
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }


            return aux;
        }
        public bool CancelarOrden(int nro)
        {
            List<SqlParameter> lst = new List<SqlParameter>();
            lst.Add(new SqlParameter("@nro", nro));
            if(DBHelper.GetInstancia().ConsultarSP("SP_CANCELAR_ORDEN", lst) != 0)
            {
                return true;
            }
            return false;
        }

        public List<Componente> ObtenerComponentes()
        {
            DataTable tabla = DBHelper.GetInstancia().Consultar("SP_CONSULTAR_COMPONENTES");
            List<Componente> lista = new List<Componente>();

            foreach (DataRow row in tabla.Rows)
            {
                int cod = int.Parse(row["codigo"].ToString());
                string nombre = row["nombre"].ToString();
                Componente c = new Componente(cod, nombre);
                lista.Add(c);
            }

            return lista;
        }

        public List<OrdenProduccion> ObtenerOrdenesProduccion(DateTime? fecha, string? estado)
        {
            var lstParams = new List<SqlParameter>();
            
            //Validar valores que puede ser nulos en los parámetros del SP
            if(!fecha.HasValue)
                lstParams.Add(new SqlParameter("@fecha", DBNull.Value));
            else
                lstParams.Add(new SqlParameter("@fecha", fecha));
            
            if(string.IsNullOrEmpty(estado))
                lstParams.Add(new SqlParameter("@estado", DBNull.Value));
            else
                lstParams.Add(new SqlParameter("@estado", estado));
            
            
            DataTable tabla = DBHelper.GetInstancia().Consultar("SP_CONSULTAR_ORDENES", lstParams);
            List<OrdenProduccion> lista = new List<OrdenProduccion>();

            foreach (DataRow row in tabla.Rows)
            {
                int nro = int.Parse(row["nro_orden"].ToString());
                DateTime fec =  DateTime.Parse(row["fecha"].ToString());
                string modelo = row["modelo"].ToString();
                string est = row["estado"].ToString();
                int cantidad = int.Parse(row["cantidad"].ToString());

                var orden = new OrdenProduccion()
                {
                    Nro = nro,
                    Fecha = fec,
                    Modelo = modelo,
                    Estado = est,
                    Cantidad = cantidad
                };

                lista.Add(orden);
            }

            return lista;
        }
    }
}
