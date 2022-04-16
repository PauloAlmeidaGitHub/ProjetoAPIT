using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAPIT.Repository.Contexts;
using ProjetoAPIT.Repository.Interfaces;
using ProjetoAPIT.Repository.Repositories;

namespace ProjetoAPIT.Services.Configurations
{
    public class RepositoryConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //capturando a string de conexão do banco de dados
            var connectionstring = configuration.GetConnectionString("ProjetoAPIT");

            //mapear a classe SqlServerContext do projeto Repository
            services.AddDbContext<SqlServerContext>
                (conn => conn.UseSqlServer(connectionstring));

            //mapeando cada repositorio do projeto
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
        }
    }
}
