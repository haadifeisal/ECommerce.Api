using ECommerce.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();

            if(!products.Any()) {
                return NoContent();
            }

            return Ok(products);

        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<ActionResult> GetProduct([FromRoute] Guid productId)
        {
            var product = await _productService.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

    }
}
