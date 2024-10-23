﻿using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using ProductGrpc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ProductService.ProductServiceClient _productServiceClient;


        public OrderController(HttpClient httpClient, ProductService.ProductServiceClient productServiceClient)
        {
            _httpClient = httpClient;
            _productServiceClient = productServiceClient;
        }

        [HttpGet("GetOrderWithProducts")]
        public async Task<IActionResult> GetOrderWithProducts()
        {
            // Call the ProductService to get product details
            var productResponse = await _httpClient.GetAsync("https://localhost:5000/gateway/products/product/GetAllProducts");
            var products = await productResponse.Content.ReadAsStringAsync();

            using var channel = GrpcChannel.ForAddress("https://localhost:5005"); // Product service URL
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
