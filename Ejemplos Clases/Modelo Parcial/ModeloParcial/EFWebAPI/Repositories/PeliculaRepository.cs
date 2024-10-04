using EFWebAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace EFWebAPI.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private db_cineContext _context;
        public PeliculaRepository(db_cineContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var entity = _context.Peliculas.Find(id);
            if(entity != null)
            {
                _context.Peliculas.Remove(entity);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.Where(x=> x.Estreno==true).ToList();
        }

        public Pelicula? GetById(int id)
        {
            var entity = _context.Peliculas.Find(id);
            if(entity != null)
            {
                return entity;
            }
            return null;
        }
        public List<Pelicula> GetByYear(int anioA, int anioB)
        {
            return _context.Peliculas.Where(x => x.Estreno == false && (x.Anio >= anioA && x.Anio <= anioB)).ToList();
        }
        public List<Pelicula> GetByGeneroAndYear(int genero, int anioA, int anioB)
        {
            return _context.Peliculas.Where(x => x.IdGenero == genero && (x.Anio >= anioA && x.Anio <= anioB)).ToList();
        }
        public bool Save(Pelicula pelicula)
        {
            if (Validate(pelicula))
            {
                _context.Peliculas.Add(pelicula);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Validate(Pelicula pelicula)
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
                else if(pelicula.Estreno == false)
                {
                    return false;
                }
                else if(pelicula.Anio == 0)
                {
                    return false;
                }
                else if(pelicula.IdGenero == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool Update(Pelicula pelicula, int id)
        {
            var entity = _context.Peliculas.Find(id);
            if (entity == null) return false;
            entity.Director = pelicula.Director;
            entity.Estreno = pelicula.Estreno;
            entity.Anio = pelicula.Anio;
            entity.IdGenero = pelicula.IdGenero;
            entity.Titulo = pelicula.Titulo;
            entity.MotivoBaja = pelicula.MotivoBaja;
            entity.FechaBaja = pelicula.FechaBaja;
            _context.Peliculas.Update(entity);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteByReason(int id, DateTime fechaBaja, string motivoBaja)
        {
            var entity = _context.Peliculas.Find(id);
            if (entity == null || entity.Estreno == false) return false;
            entity.MotivoBaja = motivoBaja;
            entity.FechaBaja = fechaBaja;
            entity.Estreno = false;
            _context.Peliculas.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
