using practico01.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practico01.Data
{
    public interface IProject
    {
        List<Factura> GetAll();
        Factura GetFacturaById(int id);
        bool Save(Factura oFactura);
        bool Delete(int id);
        bool Update(int id);

    }
}
