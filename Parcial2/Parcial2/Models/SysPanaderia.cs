using Parcial2.Enums;

namespace Parcial2.Models
{
    public class SysPanaderia
    {
        static List<Productos> Inventario = new List<Productos>();
        static string archivoInventario = "archivoInventario.txt";
        public static void AgregarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad de stock: ");
            int stock;
            while (!int.TryParse(Console.ReadLine(), out stock))
            {
                Console.WriteLine("El valor es invalido.");
            }

            Console.WriteLine("Ingrese el valor: ");
            double precio;
            while (!double.TryParse(Console.ReadLine(), out precio))
            {
                Console.WriteLine("El valor es invalido.");
            }

            Console.WriteLine("Elija el tipo de categoria: ");
            TipoCategoria categoria;
            while (!Enum.TryParse(Console.ReadLine(),true, out categoria))
            {
                Console.WriteLine("Opcion incorrecta.");
            }

            Inventario.Add(new Productos(nombre, stock, precio, categoria));
            Console.WriteLine("Producto Agregado.");
        }
        public static void GuardarInventario()
        {
            using (StreamWriter writer = new StreamWriter(archivoInventario))
            {
                foreach (var producto in Inventario)
                {
                    writer.WriteLine($"{producto.Nombre}, {producto.Stock}, {producto.Precio}, {producto.Categoria}");
                }
            }
        }

        public static void EliminarProducto()
        {
            Console.WriteLine("Ingrese el producto que desea eliminar: ");
            string nombre = Console.ReadLine();
            bool productoEncontrado = false;

            foreach (var producto in Inventario)
            {
                if (producto.Nombre == nombre)
                {
                    productoEncontrado = true;
                    Inventario.Remove(producto);
                    Console.WriteLine("producto eliminado");
                }
                else
                {
                    Console.WriteLine("producto no encontrado");
                }
            }
            
        }

        public static void ActualizarInventario()
        {
            Console.WriteLine("Ingrese el producto que desea actualizar: ");
            string nombre = Console.ReadLine();
            bool productoEncontrado = false;

            foreach (var producto in Inventario)
            {
                if (producto.Nombre == nombre)
                {
                    productoEncontrado = true;
                    Console.WriteLine("Ingrese el nuevo valor: ");
                    double nuevoPrecio = double.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el nuevo stock: ");
                    int nuevoStock = int.Parse(Console.ReadLine());

                    producto.Precio = nuevoPrecio;
                    producto.Stock = nuevoStock;
                }
                if (!productoEncontrado)
                {
                    Console.WriteLine("El producto no fue encontrado.");
                }
            }
            
        }   

        public static void MostrarInventario()
        {
            Console.WriteLine("Lista de productos:");
            foreach (var producto in Inventario)
            {
                Console.WriteLine(producto);
            }
        }

        public static void CargarInventario()
        {
            if (File.Exists(archivoInventario))
            {
                using (StreamReader reader = new StreamReader(archivoInventario))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] datos = linea.Split('|');
                        string nombre = datos[0];
                        int stock = int.Parse(datos[1]);
                        double precio = double.Parse(datos[2]);
                        TipoCategoria categoria = (TipoCategoria)Enum.Parse(typeof(TipoCategoria), datos[3]);

                        Inventario.Add(new Productos(nombre, stock, precio, categoria));
                    }
                }
            }
        }
        public static void SumarInventario()
        {
            double sum = 0;
            foreach(var producto in Inventario)
            {
               sum = producto.Precio + sum;
            }
        }
    }
}
