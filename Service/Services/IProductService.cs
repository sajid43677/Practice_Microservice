using Core.Domains;

namespace Service.Services
{
    public interface IProductService
    {
        bool CreateProduct(Product product);
        Product? DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        IEnumerable<Product> GetProductsAbovePrice(int price);
        Product? UpdateProduct(Product product);
    }
}
