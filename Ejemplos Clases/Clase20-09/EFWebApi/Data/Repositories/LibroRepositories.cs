using EFWebApi.Models;

namespace EFWebApi.Data.Repositories
{
    public class LibroRepositories : ILibroRepository
    {
        db_librosContext _context;
        public LibroRepositories(db_librosContext context)
        {
            _context = context;
        }
        public void Create(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var libroDeleted = Get(id);
            if(libroDeleted != null)
            {
                _context.Libros.Remove(libroDeleted);
                _context.SaveChanges();
            }
        }

        public Libro? Get(int id)
        {
            return _context.Libros.Find(id);
        }

        public List<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public void Update(Libro libro)
        {
            if(libro != null)
            {
                _context.Libros.Update(libro);
                _context.SaveChanges();
            }
        }
    }
}
