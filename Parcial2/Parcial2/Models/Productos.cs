using Parcial2.Enums;

namespace Parcial2.Models
{
    public class Productos
    {
       public string Nombre { get; set; }

       public int Stock { get; set; }

       public double Precio {  get; set; }

       public TipoCategoria Categoria { get; set; }


        public Productos(string nombre, int stock, double precio,TipoCategoria categoria) 
        {
            Nombre = nombre;
            Stock = stock;
            Precio = precio;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Stock}, {Precio}, {Categoria}";
        }
    }
}
