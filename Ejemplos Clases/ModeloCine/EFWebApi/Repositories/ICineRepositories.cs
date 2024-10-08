using EFWebApi.Models;

namespace EFWebApi.Repositories
{
    public interface ICineRepositories
    {
        bool Save(Pelicula p); 
        bool Delete(int id);
        List<Pelicula> GetAll();
        Pelicula? GetById(int id);
    }
}
