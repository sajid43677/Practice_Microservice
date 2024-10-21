using Core.Domains;
using Data.Configuration;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class ProductRepo : IProductRepo
{
    private readonly IDbContextFactory<AppDbContext> _contextFactory;

    public ProductRepo(IDbContextFactory<AppDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> CreateProductAsync(Product product)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        await context.Products.AddAsync(product);

        return await context.SaveChangesAsync() >= 0;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return false;
        }

        context.Products.Remove(product);
        return await context.SaveChangesAsync() >= 0;
    }

    public async Task<Product?> UpdateProductAsync(Product product)
    { 
        using var context = await _contextFactory.CreateDbContextAsync();
        context.Products.Update(product);
        await context.SaveChangesAsync();
        return product;
    }

}
