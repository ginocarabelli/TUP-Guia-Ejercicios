using EFWebApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace EFWebApi.Repositories
{
    public class CineRepository : ICineRepositories
    {
        private db_cineContext _dbContext;
        public CineRepository(db_cineContext dbconext)
        {
            _dbContext = dbconext;
        }
        public bool Delete(int id)
        {
            var entity = _dbContext.Peliculas.Where(p => p.Estreno == true && p.Id == id).ToList().FirstOrDefault();
            if (entity != null)
            {
                entity.Estreno = false;
                _dbContext.Peliculas.Update(entity);
                return _dbContext.SaveChanges() == 1;
            }
            return false;
        }

        public List<Pelicula> GetAll()
        {
            return _dbContext.Peliculas.Where(p => p.Estreno == true).ToList();
        }

        public Pelicula? GetById(int id)
        {
            return _dbContext.Peliculas.Find(id);
        }

        public bool Save(Pelicula p)
        {
            if(validarDatos(p)) 
            {
                _dbContext.Peliculas.Add(p);
                return _dbContext.SaveChanges() == 1;
            }
            return false;
        }

        private bool validarDatos(Pelicula p)
        {
            return(!string.IsNullOrEmpty(p.Titulo) && !string.IsNullOrEmpty(p.Director) && p.Anio != null && p.Estreno == true && p.IdGenero >0);
        }
    }
}
