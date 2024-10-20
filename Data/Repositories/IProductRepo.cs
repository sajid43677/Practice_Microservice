using Core.Domains;

namespace Data.Repositories
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        bool CreateProduct(Product product);
        bool DeleteProduct(int id);
        Product? UpdateProduct(Product product);
    }
}
