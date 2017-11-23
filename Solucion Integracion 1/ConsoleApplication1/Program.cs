using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri("http://localhost:58410/");
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string servicio = "api/CATEGORIAs";
                var categoria = new CATEGORIA()
                {
                    Id = 1,
                    Descripcion = "ss"
                };
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("error:"+ex.Message);
            }
        }
    }
}
