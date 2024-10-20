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

    public IEnumerable<Product> GetAllProducts()
    {
        // Use the context factory to create a fresh context
        using var context = _contextFactory.CreateDbContext();
        return context.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Products.FirstOrDefault(p => p.Id == id);
    }

    public bool CreateProduct(Product product)
    {
        using var context = _contextFactory.CreateDbContext();
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        context.Products.Add(product);
        return context.SaveChanges() >= 0;
    }

    public bool DeleteProduct(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var product = context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return false;
        }
        context.Products.Remove(product);
        return context.SaveChanges() >= 0;
    }

    public Product? UpdateProduct(Product product)
    { 
        using var context = _contextFactory.CreateDbContext();
        context.Products.Update(product);
        context.SaveChanges();
        return product;
    }

}
