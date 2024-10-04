using TurnoApi.Models;

namespace TurnoApi.Services
{
    public interface ITurnoService
    {
        List<TTurno> GetAll();
        bool Save(TTurno turno);
        bool Update(TTurno turno , int id);
        bool Delete(int id,string motivo);
    }
}
