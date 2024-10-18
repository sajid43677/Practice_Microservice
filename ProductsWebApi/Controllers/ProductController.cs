using Microsoft.AspNetCore.Mvc;
using ProductsWebApi.Factories;
using Service.Models;

namespace ProductsWebApi.Controllers
{
    [Route("api/ProductService")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductModelFactory productModelFactory;
        public ProductController(IProductModelFactory productModelFactory)
        {
            this.productModelFactory = productModelFactory;
        }

        [HttpGet("GetAllProducts")]
        public ActionResult<IEnumerable<ProductReadModel>> GetAllProducts()
        {
            return Ok(productModelFactory.GetAllProducts());
        }

        [HttpGet("GetProductById/{id}")]
        public ActionResult<ProductReadModel> GetProductById(int id)
        {
            return Ok(productModelFactory.GetProductById(id));
        }

        [HttpPost("CreateProduct")]
        public ActionResult<ProductReadModel> CreateProduct(ProductCreateModel productCreateModel)
        {
            return Ok(productModelFactory.CreateProduct(productCreateModel));
        }
    }
}
