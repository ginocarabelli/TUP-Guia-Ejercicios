using EFWebAPI.Models;

namespace EFWebAPI.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetAll();
        List<Pelicula> GetByYear(int anioA, int anioB);
        List<Pelicula> GetByGeneroAndYear(int genero, int anioA, int anioB);
        bool DeleteByReason(int id, DateTime fechaBaja, string motivoBaja);
        Pelicula? GetById(int id);
        bool Save(Pelicula pelicula);
        bool Delete(int id);
        bool Update(Pelicula pelicula, int id);
    }
}
