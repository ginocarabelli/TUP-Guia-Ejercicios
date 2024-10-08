using ParcialWebApi.Models;

namespace ParcialWebApi.Repositories
{
    public interface ICriptoRepository
    {
        List<Criptomoneda> GetByCat(int categoria);
        bool Update(string simbolo, DateTime fecha, double ultimaCot);
        bool Delete(int id);
    }
}
