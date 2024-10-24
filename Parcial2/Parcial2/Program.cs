using Parcial2.Enums;
using Parcial2.Models;

class Program
{
    static void Main()
    {
        SysPanaderia.CargarInventario();

        int opcion;

        do
        {
            Console.WriteLine("\n");
            Console.WriteLine("--- MENU ---");
            Console.WriteLine("1. Agregar producto.");
            Console.WriteLine("2. Eliminar producto.");
            Console.WriteLine("3. Actualizar producto.");
            Console.WriteLine("4. Mostrar inventario.");
            Console.WriteLine("5. Calcular total de inventario.");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    SysPanaderia.AgregarProducto();
                    break;
                case 2:
                    SysPanaderia.EliminarProducto();
                    break;
                case 3:
                    SysPanaderia.ActualizarInventario();
                    break;
                case 4:
                    SysPanaderia.MostrarInventario();
                    break;
                case 5:
                    SysPanaderia.SumarInventario();
                    break;
            }
        } while (opcion != 6);

        SysPanaderia.GuardarInventario();
    }
}