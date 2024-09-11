namespace Problema4.Models
{
    public class Product
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public Product(int codigo, string nombre, double precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }
    }
}
