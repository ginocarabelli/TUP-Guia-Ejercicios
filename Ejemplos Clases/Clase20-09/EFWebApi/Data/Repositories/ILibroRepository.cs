using EFWebApi.Models;

namespace EFWebApi.Data.Repositories
{
    public interface ILibroRepository
    {
        void Create(Libro libro);
        void Update(Libro libro);
        Libro? Get(int id);
        void Delete(int id);
        List<Libro> GetAll();
    }
}
