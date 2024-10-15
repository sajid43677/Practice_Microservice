using Microsoft.EntityFrameworkCore;

namespace Products.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Models.Product> Products { get; set; }
    }
}
