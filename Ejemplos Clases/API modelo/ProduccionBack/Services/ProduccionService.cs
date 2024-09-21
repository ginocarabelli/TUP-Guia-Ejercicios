using ProduccionBack.Data;
using ProduccionBack.Entities;

namespace ProduccionBack.Services
{
    public class ProduccionService : IProduccionService
    {
        private IOrdenRepository repository;
        public ProduccionService()
        {
            repository = new OrdenRepository();
        }
        public List<Componente> ConsultarComponentes()
        {
            return repository.ObtenerComponentes();
        }
        public bool RegistrarProduccion(OrdenProduccion orden)
        {
            return repository.CrearOrden(orden);
        }
        public List<OrdenProduccion> ConsultarOrdenes(DateTime? fecha, string? estado)
        {
            return repository.ObtenerOrdenesProduccion(fecha, estado);
        }
    }
}
