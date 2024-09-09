
using RepositoryExample.Data;
using RepositoryExample.Domain;
using RepositoryExample.Services;

ProductManager manager = new ProductManager();

//Create new product:
var oProduct = new Product()
{
    Nombre = "PRODUCTO DE PRUEBA",
    Stock = 2000,
    Activo = true
};
if (manager.SaveProduct(oProduct))
    Console.WriteLine("PRODUCTO CREADO EXISTOSAMENTE!");

//List all product of store:
List<Product> lst = manager.GetProducts();
if(lst.Count == 0)
{
    Console.WriteLine("Sin productos en la base de datos");

}
else
{
    foreach(var oProducto in lst)
    {
        Console.WriteLine(oProducto);
    }
}

//Delete product cod = 1:
if (manager.DeleteProduct(1))
    Console.WriteLine("PRODUCTO ACTUALIZADO CON DATOS DE BAJA!");

BudgetManager budgetManager = new BudgetManager();
var bugdets = budgetManager.GetBudgets();
var budget01 = budgetManager.GetBudgetsById(1); 

