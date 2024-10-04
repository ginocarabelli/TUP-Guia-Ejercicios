using EFWebApi.Models;
using EFWebApi.Repositories;

namespace EFWebApi.Services
{
    public class PeliculaServices : IPeliculaServices
    {
        private IPeliculaRepository _repo;
        public PeliculaServices(IPeliculaRepository repo)
        {
            _repo = repo;
        }

        public bool Delete(int id, string? motivoBaja)
        {
            return _repo.Delete(id, motivoBaja);
        }

        public List<Pelicula> GetAll()
        {
            return _repo.GetAll();
        }

        public Pelicula? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public bool Save(Pelicula pelicula)
        {
            return _repo.Save(pelicula);
        }

        public bool Update(int id, bool estreno)
        {
            return _repo.Update(id, estreno);
        }
    }
}
