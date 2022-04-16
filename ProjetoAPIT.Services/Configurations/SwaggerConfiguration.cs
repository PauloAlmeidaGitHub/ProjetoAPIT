using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ProjetoAPIT.Services.Configurations
{
    public class SwaggerConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de funcionarios com TDD",
                    Description = "Projeto desenvolvido em NET 5 API com SqlServer",
                    Contact = new OpenApiContact
                    {
                        Name = "API de Testes",
                        Url = new Uri("https://transpetro.com.br/transpetro-institucional/"),
                        Email = "paulo.cezar.almeida.hitss_do_brasil@transpetro.com.br@"
                    }
                });
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPIT");
            });
        }
    }
}
