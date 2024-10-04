using EFWebAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace EFWebAPI.Repositories
{
    public class EnviosRepository : IEnviosRepository
    {
        private db_enviosContext _context;
        public EnviosRepository(db_enviosContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var entity = _context.TEnvios.Where(e => e.Codigo == id && e.Estado != "Cancelado").ToList().FirstOrDefault();
            if(entity != null)
            {
                entity.Estado = "Cancelado";
                _context.TEnvios.Update(entity);
                return _context.SaveChanges() == 1;
            }
            return false;
        }

        public List<TEnvio> GetAll(DateTime fechaA, DateTime fechaB)
        {
            return _context.TEnvios.Where(e => e.FechaEnvio >= fechaA && e.FechaEnvio <= fechaB && e.Estado != "Cancelado").ToList();
        }

        public bool Save(TEnvio envio)
        {
            if(envio != null)
            {
                if(envio.Estado.IsNullOrEmpty())
                {
                    return false;
                }
                else if (envio.Direccion.IsNullOrEmpty())
                {
                    return false;
                }
                else if (envio.DniCliente.IsNullOrEmpty())
                {
                    return false;
                }
                else if (envio.IdEmpresa == 0 || envio.IdEmpresa == null)
                {
                    return false;
                }
                else if (envio.FechaEnvio == null)
                {
                    envio.FechaEnvio = DateTime.Now;
                    return false;
                }
                else
                {
                    _context.TEnvios.Add(envio);
                    return _context.SaveChanges() == 1;
                }
            }
            return false;
        }
    }
}
