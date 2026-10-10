using Microsoft.Data.SqlClient;
using RegistroGastoBD;

namespace GastosDB
{
    public class Program
    {
        private const string CadenaConexion =
            @"Server=(localdb)\MSSQLLocalDB;" +
            @"Database=GastosDB;" +
            @"Trusted_Connection=True;" +
            @"TrustServerCertificate=True;";

        public static void Main(string[] args)
        {
            try
            {
                List<Gasto> gastos = Cargar();

                if (gastos.Count == 0)
                {
                    Console.WriteLine("No hay gastos registrados.");
                    return;
                }

                decimal totalGeneral = 0;

                Console.WriteLine(
                    $"{"Id",-3} {"Descripción",-20} {"Monto",10} {"Categoría",-15}");

                foreach (Gasto gasto in gastos)
                {
                    Console.WriteLine(gasto);
                    totalGeneral += gasto.Monto;
                }

                Console.WriteLine();
                Console.WriteLine($"TOTAL GASTADO: Q {totalGeneral:N2}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de SQL Server.");
                Console.WriteLine("Detalle: " + ex.Message);
                Console.WriteLine("Número de error: " + ex.Number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error.");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Presiona una tecla para salir.");
            Console.ReadKey();
        }

        private static List<Gasto> Cargar()
        {
            List<Gasto> listaGastos = new List<Gasto>();

            using (SqlConnection conexion =
                new SqlConnection(CadenaConexion))
            {
                conexion.Open();

                string consulta =
                    "SELECT Id, Descripcion, Monto, Categoria FROM Gastos";

                using (SqlCommand comando =
                    new SqlCommand(consulta, conexion))
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Gasto gasto = new Gasto
                        {
                            Id = lector.GetInt32(0),
                            Descripcion = lector.GetString(1),
                            Monto = lector.GetDecimal(2),
                            Categoria = lector.GetString(3)
                        };

                        listaGastos.Add(gasto);
                    }
                }
            }

            return listaGastos;
        }
    }
}
