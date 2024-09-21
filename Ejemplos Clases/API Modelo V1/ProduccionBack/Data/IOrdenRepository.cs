using ProduccionBack.Entities;

namespace ProduccionBack.Data
{
    public interface IOrdenRepository
    {
        List<Componente> ObtenerComponentes();
        bool CrearOrden(OrdenProduccion orden);
        bool CancelarOrden(int nro);
        List<OrdenProduccion> ObtenerOrdenesProduccion(DateTime? fecha, string? estado);



    }
}
