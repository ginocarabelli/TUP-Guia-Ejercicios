using RepositoryExample.Data;
using RepositoryExample.Domain;
using RepositoryExample.Services;
using System.Collections.Generic;

ProductManager manager = new ProductManager();
List<Product> lst = manager.GetProducts();

if (lst.Count == 0)
{
    Console.WriteLine("Sin productos en la bd.");
}
else
{
    foreach(var oProducto in lst)
    {
        Console.WriteLine(oProducto);
    }
}