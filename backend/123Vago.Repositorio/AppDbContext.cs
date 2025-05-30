using _123Vago.Dominio;
using Microsoft.EntityFrameworkCore;

namespace _123Vago.Repositorio
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
