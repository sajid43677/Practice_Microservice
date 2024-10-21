using Core.Domains;
using Data.Repositories;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repository;
        public ProductService(IProductRepo repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            return await _repository.CreateProductAsync(product);
        }

        public async Task<IEnumerable<Product>> GetProductsAbovePriceAsync(int price)
        {
            return (await _repository.GetAllProductsAsync()).Where(p => p.Price > price).ToList();
        }

        public async Task<Product?> DeleteProductAsync(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            if (await _repository.DeleteProductAsync(id))
            {
                return product;
            }

            throw new ArgumentException("Invalid Id.");
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            if (product == null || product.Id <= 0)
            {
                throw new ArgumentException("Invalid product data.");
            }

            var existingProduct = await _repository.GetProductByIdAsync(product.Id);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product not found.");
            }

            return await _repository.UpdateProductAsync(product);
        }
    }
}
