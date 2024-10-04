using TurnoApi.Models;

namespace TurnoApi.Repositorios
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly TurnosDbContext _context;
        public TurnoRepository(TurnosDbContext context)
        {
            _context = context;
        }
        public bool Delete(int id, string motivo)
        {
            var turno = _context.TTurnos.Find(id);
            if (turno != null)
            {
                turno.FechaCancelacion = DateTime.Now;
                turno.MotivoCancelacion = motivo;
                _context.TTurnos.Update(turno);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<TTurno> GetAll()
        {
            return _context.TTurnos
               .Where(x => !x.FechaCancelacion.HasValue) // x.FechaCancelacion == null
                .ToList();
        }

        public bool Save(TTurno turno)
        {
            _context.TTurnos.Add(turno);
            return _context.SaveChanges() > 0;
        }

        public bool Update(TTurno turno, int id)
        {
            var entity = _context.TTurnos.Find(id);
            if (entity == null) return false;
            entity.Cliente = turno.Cliente;
            entity.Fecha = turno.Fecha;
            entity.Hora = turno.Hora;
            _context.TTurnos.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
