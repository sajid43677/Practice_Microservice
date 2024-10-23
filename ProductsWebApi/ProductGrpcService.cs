using Core.Domains;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductGrpc;
using Service.Services;

namespace ProductsWebApi
{
    public class ProductGrpcService : ProductGrpc.ProductService.ProductServiceBase
    {
        private readonly IProductService productService;

        public ProductGrpcService(IProductService productService)
        {
            this.productService = productService;
        }

        public override async Task<ProductListModel> GetAllProducts(ProductGrpc.Empty request, ServerCallContext context)
        {
            var products = await productService.GetAllProductsAsync();

            var response = new ProductListModel();
            foreach (var item in products)
            {
                response.ProductReadModels.Add(new ProductReadModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price
                });
            }

            return response;
        }
    }
}
