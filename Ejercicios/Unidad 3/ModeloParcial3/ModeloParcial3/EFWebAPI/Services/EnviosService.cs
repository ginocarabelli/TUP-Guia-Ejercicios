using EFWebAPI.Models;
using EFWebAPI.Repositories;

namespace EFWebAPI.Services
{
    public class EnviosService : IEnviosService
    {
        private IEnviosRepository _repo;
        public EnviosService(IEnviosRepository repo)
        {
            _repo = repo;
        }
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<TEnvio> GetAll(DateTime fechaA, DateTime fechaB)
        {
            return _repo.GetAll(fechaA, fechaB);
        }

        public bool Save(TEnvio envio)
        {
            return _repo.Save(envio);
        }
    }
}
