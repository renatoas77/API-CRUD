using Aplicativo_de_cadastro_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplicativo_de_cadastro_crud.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}
