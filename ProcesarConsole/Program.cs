using ProcesarApi.Models;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProcesarConsole
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<Double> ProcesarOperacionAsync(Operacion operacion)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/operaciones", operacion);
            response.EnsureSuccessStatusCode();
  
            double op = await response.Content.ReadAsAsync<Double>();
            return op;
        }

        static void Main()
        {
            // Basado en
            // https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:54108/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Console.WriteLine("Seleccione el operacion: \n 1.Suma 2.Resta 3.Multiplicacion 4.Division");
                string operacionRealizar = SelTipoOperacion(Console.ReadLine());

                Console.WriteLine("\nIngrese valor:");
                double.TryParse(Console.ReadLine(), out double primerValor);

                Console.WriteLine("Ingrese otro valor:");
                double.TryParse(Console.ReadLine(), out double segundoValor);

                Operacion operacion = new Operacion {
                    TipoOperacion = operacionRealizar,
                    Valor1 = primerValor,
                    Valor2 = segundoValor
                };

                var resultPlease = await ProcesarOperacionAsync(operacion);

                Console.WriteLine("Resultado: " + resultPlease);
                Console.WriteLine("Digite una tecla para finalizar...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static string SelTipoOperacion(String numeroSeleccionado)
        {

            switch (numeroSeleccionado)
            {
                case "1":
                    return "Suma";
                case "2":
                    return "Resta";
                case "3":
                    return "Multiplicacion";
                case "4":
                    return "Division";
                default:
                    return "Operacion invalida";
            }
        }
    }
}
