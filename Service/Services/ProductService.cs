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

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return _repository.GetProductById(id);
        }

        public bool CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            return _repository.CreateProduct(product);
        }

        public IEnumerable<Product> GetProductsAbovePrice(int price)
        {
            return _repository.GetAllProducts().Where(p => p.Price > price).ToList();
        }

        public Product? DeleteProduct(int id)
        {
            var product = _repository.GetProductById(id);

            if (_repository.DeleteProduct(id))
            {
                return product;
            }

            throw new ArgumentException("Invalid Id.");
        }

        public Product? UpdateProduct(Product product)
        {
            if (product == null || product.Id <= 0)
            {
                throw new ArgumentException("Invalid product data.");
            }

            var existingProduct = _repository.GetProductById(product.Id);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product not found.");
            }

            return _repository.UpdateProduct(product);
        }
    }
}
