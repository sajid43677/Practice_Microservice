using Service.Models;

namespace ProductsWebApi.Factories
{
    public interface IProductModelFactory
    {
        ProductReadModel CreateProduct(ProductCreateModel productCreateModel);
        IEnumerable<ProductReadModel> GetAllProducts();
        ProductReadModel GetProductById(int id);
    }
}
