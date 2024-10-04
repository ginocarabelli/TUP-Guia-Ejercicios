using TurnoApi.Models;
using TurnoApi.Repositorios;

namespace TurnoApi.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;
        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }
        public bool Delete(int id,string motivo)
        {
            return _turnoRepository.Delete(id,motivo);
        }

        public List<TTurno> GetAll()
        {
            return _turnoRepository.GetAll();
        }

        public bool Save(TTurno turno)
        {
            return _turnoRepository.Save(turno);
        }

        public bool Update(TTurno turno, int id)
        {
            return _turnoRepository.Update(turno,id);
        }
    }
}
