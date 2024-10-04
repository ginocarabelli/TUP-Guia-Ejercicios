using EFWebAPI.Models;

namespace EFWebAPI.Services
{
    public interface IPeliculaService
    {
        List<Pelicula> GetAll();
        Pelicula? GetById(int id);
        List<Pelicula> GetByYear(int anioA, int anioB);
        List<Pelicula> GetByGeneroAndYear(int genero, int anioA, int anioB);
        bool DeleteByReason(int id, DateTime fechaBaja, string motivoBaja);
        bool Save(Pelicula pelicula);
        bool Delete(int id);
        bool Update(Pelicula pelicula, int id);
    }
}
