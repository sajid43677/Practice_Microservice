using Core.Domains;
using Data.Configuration;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public ProductListModel GetProducts()
        {
            var products = _productService.GetAllProducts();
            return _productModelFactory.PrepareProductListModel(products);
        }

        public ProductReadModel GetProductById(int id)
        {
            var product = _productService.GetProduct(id);
            return _productModelFactory.PrepareProductReadModel(product);
        }

    }
}
