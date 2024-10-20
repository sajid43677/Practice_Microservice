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

        public ProductModelFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductReadModel PrepareProductReadModel(Product product)
        {
            return _mapper.Map<ProductReadModel>(product);
        }

        public ProductListModel PrepareProductListModel(IEnumerable<Product> products)
        {
            var productListModel = new ProductListModel();

            foreach (var product in products)
            {
                productListModel.ProductReadModels.Add(PrepareProductReadModel(product));
            }

            return productListModel;
        }

    }
}
