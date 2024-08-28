using RepositoryExample.Data;
using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Services
{
    public class ProductManager
    {
        private IProductRepository _repository;

        public ProductManager()
        {
            _repository = new ProductRepositoryADO();
        }
        public List<Product> GetProducts()
        {
            return _repository.GetAll();
        }
    }
}
