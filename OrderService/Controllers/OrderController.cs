using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("GetOrderWithProducts")]
        public async Task<IActionResult> GetOrderWithProducts()
        {
            // Call the ProductService to get product details
            var productResponse = await _httpClient.GetAsync("https://localhost:5001/api/product/GetAllProducts");
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
