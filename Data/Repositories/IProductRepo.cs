using Core.Domains;

namespace Data.Repositories
{
    public interface IProductRepo
    {
        Task<bool> CreateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product?> UpdateProductAsync(Product product);
    }
}
