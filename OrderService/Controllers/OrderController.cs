using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using ProductGrpc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }

        [HttpGet("GetOrderWithProducts")]
        public async Task<IActionResult> GetOrderWithProducts()
        {
            // Call the ProductService to get product details
            using var channel = GrpcChannel.ForAddress(OrderServiceDefault.ProductGrpcServiceUrl); // Product service URL
            var client = new ProductService.ProductServiceClient(channel);

            var productsResponse = await client.GetAllProductsAsync(new Empty());

            var order = new
            {
                OrderId = 123,
                Products = productsResponse.ProductReadModels
            };

            return Ok(order);
        }
    }
}
