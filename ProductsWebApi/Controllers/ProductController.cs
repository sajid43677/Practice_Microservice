using AutoMapper;
using Core.Domains;
using Microsoft.AspNetCore.Mvc;
using ProductsWebApi.Factories;
using Service.Models;
using Service.Services;

namespace ProductsWebApi.Controllers
{
    [Route("api/ProductService")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductModelFactory productModelFactory;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductModelFactory productModelFactory, IProductService productService, IMapper mapper)
        {
            this.productModelFactory = productModelFactory;
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<ProductListModel>> GetAllProducts()
        {
            var products = await productService.GetAllProductsAsync();

            return Ok(productModelFactory.PrepareProductListModel(products));
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductReadModel>> GetProductById(int id)
        {
            var product = await productService.GetProductAsync(id);

            return product != null ? Ok(productModelFactory.PrepareProductReadModel(product)) : BadRequest();
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductReadModel>> CreateProduct(ProductCreateModel productCreateModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = mapper.Map<Product>(productCreateModel);
            var createdProduct = await productService.CreateProductAsync(product);

            return createdProduct ? Ok(productModelFactory.PrepareProductReadModel(product)) : BadRequest();
        }

        [HttpGet("GetProductsAbovePrice/{price}")]
        public async Task<ActionResult<ProductListModel>> GetProductsAbovePrice(int price)
        {
            var products = await productService.GetProductsAbovePriceAsync(price);

            return Ok(productModelFactory.PrepareProductListModel(products));
        }
    }
}
