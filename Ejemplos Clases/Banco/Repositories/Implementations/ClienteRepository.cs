using Banco.Entities;
using Banco.Repositories.Contracts;
using Banco.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Repositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        public List<Cliente> GetAll()
        {
            var clientes = new List<Cliente>();
            DataTable table = DataHelper
                .GetInstance()
                .ExecuteSPQuery("OBTENER_CLIENTES", null);

            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Dni = row["Dni"].ToString()
                    };
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        public bool Add(Cliente cliente)
        {
            var parametros = new List<ParameterSQL>
            {
                new ParameterSQL("@Nombre", cliente.Nombre),
                new ParameterSQL("@Apellido", cliente.Apellido),
                new ParameterSQL("@Dni", cliente.Dni)
            };

            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("CREAR_CLIENTE", parametros);
            return filasAfectadas > 0;
        }
    }
}
