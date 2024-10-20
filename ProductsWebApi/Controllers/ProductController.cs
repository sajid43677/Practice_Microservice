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
        public ActionResult<ProductListModel> GetAllProducts()
        {
            var products = productService.GetAllProducts();

            return Ok(productModelFactory.PrepareProductListModel(products));
        }

        [HttpGet("GetProductById/{id}")]
        public ActionResult<ProductReadModel> GetProductById(int id)
        {
            var product = productService.GetProduct(id);

            return product != null ? Ok(productModelFactory.PrepareProductReadModel(product)) : BadRequest();
        }

        [HttpPost("CreateProduct")]
        public ActionResult<ProductReadModel> CreateProduct(ProductCreateModel productCreateModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = mapper.Map<Product>(productCreateModel);
            var createdProduct = productService.CreateProduct(product);

            return createdProduct ? Ok(productModelFactory.PrepareProductReadModel(product)) : BadRequest();
        }

        [HttpGet("GetProductsAbovePrice/{price}")]
        public ActionResult<ProductListModel> GetProductsAbovePrice(int price)
        {
            var products = productService.GetProductsAbovePrice(price);

            return Ok(productModelFactory.PrepareProductListModel(products));
        }
    }
}
