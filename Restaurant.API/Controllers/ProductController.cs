using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Restaurant.API.Model;
using Restaurant.DataAccess.Entities;
using Restaurant.Domain.Services;
using System.Net;

namespace Restaurant.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly ProductService _productService;

        public ProductController(
            ILogger<BaseController> logger, 
            GraphServiceClient graphServiceClient,
            ProductService productService) 
            : base(logger, graphServiceClient)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var list = await _productService.GetProductList();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(AddNewProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product()
            {
                ProductName = model.ProductName,
                Price = model.Price,
            };
            await _productService.AddNewProduct(product);

            return StatusCode((int)HttpStatusCode.Created, product);
        }
    }
}
