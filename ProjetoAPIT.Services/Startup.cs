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
        // M�todo chamado em RUNTIME, adiciona servi�os ao Container de DI
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Configura��o do Swagger
            SwaggerConfiguration.ConfigureServices(services);

            // Configura��o do Repositorio
            RepositoryConfiguration.ConfigureServices(services, Configuration);
        }


        //===============================================================
        // // M�todo chamado em RUNTIME
        // Fornece informa��es sobre o ambiente de hospedagem na Web em que um aplicativo est� sendo executado
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();



            //Configura��o do Swagger
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
