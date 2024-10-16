using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public OrdersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderWithProducts()
        {
            // Call the ProductService to get product details
            var productResponse = await _httpClient.GetAsync("http://localhost:5001/api/products");
            var products = await productResponse.Content.ReadAsStringAsync();

            var order = new
            {
                OrderId = 123,
                Products = products
            };

            return Ok(order);
        }
    }
}
