using Core.Domains;
using Service.Models;

namespace ProductsWebApi.Factories
{
    public interface IProductModelFactory
    {
        ProductListModel PrepareProductListModel(IEnumerable<Product> products);
        ProductReadModel PrepareProductReadModel(Product product);
    }
}
