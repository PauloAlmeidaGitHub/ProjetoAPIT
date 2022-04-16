using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoAPIT.Services.Configurations;

namespace ProjetoAPIT.Services
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        
        //===============================================================
        // Método chamado em RUNTIME, adiciona serviços ao Container de DI
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Configuração do Swagger
            SwaggerConfiguration.ConfigureServices(services);

            // Configuração do Repositorio
            RepositoryConfiguration.ConfigureServices(services, Configuration);
        }


        //===============================================================
        // // Método chamado em RUNTIME
        // Fornece informações sobre o ambiente de hospedagem na Web em que um aplicativo está sendo executado
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();



            //Configuração do Swagger
            SwaggerConfiguration.Configure(app);

            
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
        //===============================================================
    }
}
