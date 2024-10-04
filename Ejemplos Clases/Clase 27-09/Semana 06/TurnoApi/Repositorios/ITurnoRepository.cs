using TurnoApi.Models;

namespace TurnoApi.Repositorios
{
    public interface ITurnoRepository
    {
        List<TTurno> GetAll();
        bool Save(TTurno turno);
        bool Update(TTurno turno, int id);
        bool Delete(int id,string motivo);
    }
}
