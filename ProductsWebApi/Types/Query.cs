using ProductsWebApi.Factories;
using Service.Models;
using Service.Services;

namespace ProductsWebApi.Types
{
    public class Query
    {
        private readonly IProductService _productService;
        private readonly IProductModelFactory _productModelFactory;
        public Query(IProductService productService, IProductModelFactory productModelFactory)
        {
            _productService = productService;
            _productModelFactory = productModelFactory;
        }

        public async Task<ProductListModel> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return _productModelFactory.PrepareProductListModel(products);
        }

        public async Task<ProductReadModel> GetProductById(int id)
        {
            var product = await _productService.GetProductAsync(id);
            return _productModelFactory.PrepareProductReadModel(product);
        }

    }
}
