using AutoMapper;
using Core.Domains;
using Data.Repositories;
using Service.Models;
using Service.Services;

namespace ProductsWebApi.Factories
{
    public class ProductModelFactory : IProductModelFactory
    {
        private readonly IMapper _mapper;
        private readonly IProductService productService;
        public ProductModelFactory(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            this.productService = productService;
        }

        public ProductReadModel GetProductById(int id)
        {
            var productItem = productService.GetProduct(id);
            return _mapper.Map<ProductReadModel>(productItem);
        }

        public ProductReadModel CreateProduct(ProductCreateModel productCreateModel)
        {
            var productItem = _mapper.Map<Product>(productCreateModel);
            var product = productService.CreateProduct(productItem);
            return product ? _mapper.Map<ProductReadModel>(productItem) : new ProductReadModel();
        }

        public IEnumerable<ProductReadModel> GetAllProducts()
        {
            var productItems = productService.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductReadModel>>(productItems);
        }

        public IEnumerable<ProductReadModel> GetProductsAbovePrice(int price)
        {
            var productItems = productService.GetProductsAbovePrice(price);
            return _mapper.Map<IEnumerable<ProductReadModel>>(productItems);
        }

    }
}
