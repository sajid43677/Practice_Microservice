using Core.Domains;

namespace Service.Services
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(Product product);
        Task<Product?> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsAbovePriceAsync(int price);
        Task<Product?> UpdateProductAsync(Product product);
    }
}
