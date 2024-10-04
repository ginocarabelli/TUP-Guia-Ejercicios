using EFWebApi.Models;

namespace EFWebApi.Repositories
{
    public interface IPeliculaRepository
    {
        public List<Pelicula> GetAll();
        public Pelicula? GetById(int id);
        public bool Save(Pelicula pelicula);
        public bool Update(int id, bool estreno);
        public bool Delete(int id, string? motivoBaja);
    }
}
