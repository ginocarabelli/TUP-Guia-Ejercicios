using ParcialWebApi.Models;

namespace ParcialWebApi.Repositories
{
    public class CriptoRepository : ICriptoRepository
    {
        private CriptoContext _context;
        public CriptoRepository(CriptoContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var entity = _context.Criptomonedas.Where(c => c.Estado == "H" && c.Id == id).ToList().FirstOrDefault();
            if (entity != null)
            {
                entity.Estado = "NH";
                _context.Criptomonedas.Update(entity);
                return _context.SaveChanges() == 1; 
            }
            return false;
        }

        public List<Criptomoneda> GetByCat(int categoria)
        {
            return _context.Criptomonedas.Where(c => c.Categoria == categoria).ToList();
        }

        public bool Update(string simbolo, DateTime fecha, double ultimaCot)
        {
            var entity = _context.Criptomonedas.Where(c => c.Simbolo == simbolo).ToList().FirstOrDefault();
            if(entity != null)
            {
                if(fecha < DateTime.Today.AddDays(-1))
                {
                    return false;
                }
                entity.UltimaActualizacion = fecha;
                entity.ValorActual = ultimaCot;
                _context.Criptomonedas.Update(entity);
                return _context.SaveChanges() == 1;
            }
            return false;
        }
    }
}
