namespace Problema2.Models
{
    public class Moneda
    {
        public string Nombre { get; set; }
        public int Valor { get; set; }

        public Moneda(string nombre, int valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
