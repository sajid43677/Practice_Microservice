using AutoMapper;
using Core.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public ProductReadModel CreateProduct(ProductCreateModel productCreateModel)
        {
            var product = _mapper.Map<Product>(productCreateModel);
            var createdProduct = _productService.CreateProduct(product);

            return _productModelFactory.PrepareProductReadModel(product);
        }

        public ProductReadModel DeleteProduct(int id)
        {
            var product = _productService.DeleteProduct(id);
            
            return _productModelFactory.PrepareProductReadModel(product);
        }

        public ProductReadModel UpdateProduct(ProductUpdateModel productUpdateModel)
        {
            var product = _mapper.Map<Product>(productUpdateModel);
            var updatedProduct = _productService.UpdateProduct(product);

            return _productModelFactory.PrepareProductReadModel(updatedProduct);
        }
    }
}
