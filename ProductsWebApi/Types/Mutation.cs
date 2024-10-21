using AutoMapper;
using Core.Domains;
using ProductsWebApi.Factories;
using Service.Models;
using Service.Services;

namespace ProductsWebApi.Types
{
    public class Mutation
    {
        private readonly IProductService _productService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IMapper _mapper;

        public Mutation(IProductService productService, IProductModelFactory productModelFactory, IMapper mapper)
        {
            _productService = productService;
            _productModelFactory = productModelFactory;
            _mapper = mapper;
        }

        public async Task<ProductReadModel> CreateProduct(ProductCreateModel productCreateModel)
        {
            var product = _mapper.Map<Product>(productCreateModel);
            var createdProduct = await _productService.CreateProductAsync(product);

            return _productModelFactory.PrepareProductReadModel(product);
        }

        public async Task<ProductReadModel> DeleteProduct(int id)
        {
            var product = await _productService.DeleteProductAsync(id);
            
            return _productModelFactory.PrepareProductReadModel(product);
        }

        public async Task<ProductReadModel> UpdateProduct(ProductUpdateModel productUpdateModel)
        {
            var product = _mapper.Map<Product>(productUpdateModel);
            var updatedProduct = await _productService.UpdateProductAsync(product);

            return _productModelFactory.PrepareProductReadModel(updatedProduct);
        }
    }
}
