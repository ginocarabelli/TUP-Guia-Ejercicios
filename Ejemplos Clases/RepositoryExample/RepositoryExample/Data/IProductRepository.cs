using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryExample.Domain;

namespace RepositoryExample.Data
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool Save(Product oProduct);
        bool Delete(int id);
        bool Update(int id);
    }
}
