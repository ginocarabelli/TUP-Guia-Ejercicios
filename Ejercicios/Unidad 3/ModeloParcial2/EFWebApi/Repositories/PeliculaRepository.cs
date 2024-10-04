using EFWebApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace EFWebApi.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private db_cineContext _context;
        public PeliculaRepository(db_cineContext context)
        {
            _context = context;
        }
        public bool Delete(int id, string? motivoBaja)
        {
            var entity = _context.Peliculas.Find(id);
            entity.Estreno = false;
            entity.FechaBaja = DateTime.Now;
            entity.MotivoBaja = motivoBaja;
            if(entity != null)
            {
                _context.Peliculas.Update(entity);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.Where(e => e.Estreno == true).ToList();
        }

        public Pelicula? GetById(int id)
        {
            return _context.Peliculas.Where(e => e.Estreno == true && e.Id == id).ToList().FirstOrDefault();
        }

        public bool Save(Pelicula pelicula)
        {
            if(pelicula != null)
            {
                if (pelicula.Titulo.IsNullOrEmpty())
                {
                    return false;
                }
                else if (pelicula.Director.IsNullOrEmpty())
                {
                    return false;
                }
                else if(pelicula.Anio == 0 || pelicula.Anio == null)
                {
                    return false;
                }
                else if(pelicula.Estreno == false)
                {
                    return false;
                }
                else if(pelicula.IdGenero == 0 || pelicula.IdGenero == null)
                {
                    return false;
                }
                else
                {
                    _context.Peliculas.Add(pelicula);
                    return _context.SaveChanges() > 0;
                }
            }
            return false;
        }

        public bool Update(int id, bool estreno)
        {
            var entity = _context.Peliculas.Find(id);
            if(entity != null)
            {
                entity.Estreno = estreno;
                _context.Peliculas.Update(entity);
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
