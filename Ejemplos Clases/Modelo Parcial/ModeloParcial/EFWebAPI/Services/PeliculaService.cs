using EFWebAPI.Models;
using EFWebAPI.Repositories;

namespace EFWebAPI.Services
{
    public class PeliculaService : IPeliculaService
    {
        private IPeliculaRepository _repo;
        public PeliculaService(IPeliculaRepository repo)
        {
            _repo = repo;
        }
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public bool DeleteByReason(int id, DateTime fechaBaja, string motivoBaja)
        {
            return _repo.DeleteByReason(id, fechaBaja, motivoBaja);
        }

        public List<Pelicula> GetAll()
        {
            return _repo.GetAll();
        }

        public List<Pelicula> GetByGeneroAndYear(int genero, int anioA, int anioB)
        {
            return _repo.GetByGeneroAndYear(genero, anioA, anioB);
        }

        public Pelicula? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Pelicula> GetByYear(int anioA, int anioB)
        {
            return _repo.GetByYear(anioA, anioB);
        }

        public bool Save(Pelicula pelicula)
        {
            return _repo.Save(pelicula);
        }

        public bool Update(Pelicula pelicula, int id)
        {
            return _repo.Update(pelicula, id);
        }
    }
}
