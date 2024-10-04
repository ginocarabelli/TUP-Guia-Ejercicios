using EFWebApi.Models;

namespace EFWebApi.Services
{
    public interface IPeliculaServices
    {
        public List<Pelicula> GetAll();
        public Pelicula? GetById(int id);
        public bool Save(Pelicula pelicula);
        public bool Update(int id, bool estreno);
        public bool Delete(int id, string? motivoBaja);
    }
}
