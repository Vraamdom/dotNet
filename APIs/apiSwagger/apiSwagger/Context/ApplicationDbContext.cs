using apiSwagger.Models;
using Microsoft.EntityFrameworkCore;

namespace apiSwagger.Context
{
    public class ApplicationDbContext:DbContext

    {
        public DbSet<Producto> Productos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
    }
}
