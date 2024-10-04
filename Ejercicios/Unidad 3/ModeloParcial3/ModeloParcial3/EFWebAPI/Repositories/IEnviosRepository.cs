using EFWebAPI.Models;

namespace EFWebAPI.Repositories
{
    public interface IEnviosRepository
    {
        List<TEnvio> GetAll(DateTime fechaA, DateTime fechaB);
        bool Delete(int id);
        bool Save(TEnvio envio);
    }
}
