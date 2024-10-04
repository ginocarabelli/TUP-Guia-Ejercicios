using EFWebAPI.Models;

namespace EFWebAPI.Services
{
    public interface IEnviosService
    {
        List<TEnvio> GetAll(DateTime fechaA, DateTime fechaB);
        bool Delete(int id);
        bool Save(TEnvio envio);
    }
}
