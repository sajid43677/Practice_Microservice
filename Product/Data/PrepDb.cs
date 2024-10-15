using Product = Products.Models.Product;

namespace Products.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                Console.WriteLine("Seeding data...");
                context.Products.AddRange(
                    new Product { Name = "Keyboard", Price = 20 },
                    new Product { Name = "Mouse", Price = 5 },
                    new Product { Name = "Monitor", Price = 150 }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already exists.");
            }
        }
    }
}
