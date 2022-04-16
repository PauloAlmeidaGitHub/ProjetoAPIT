using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace ProjetoAPIT.Tests.Helpers
{
    public class HttpClientHelper
    {
        // Método para se conectar com os serviços da API
        public static HttpClient Create()
        {
            // Ler o appsettings.json do Projeto API
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // GERAR Conexão com o projeto da API
            var server = new TestServer(new WebHostBuilder()
                                        .UseConfiguration(configuration)
                                        .UseStartup<Services.Startup>()
                                       );

            return server.CreateClient();


        }
    }
}
