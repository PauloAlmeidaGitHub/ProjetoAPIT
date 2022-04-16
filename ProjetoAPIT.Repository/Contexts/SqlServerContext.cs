using Microsoft.EntityFrameworkCore;
using ProjetoAPIT.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPIT.Repository.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> context) : base(context)
        {
            
        }

        public DbSet<Funcionario> Funcionario { get; set; }


    }
}
