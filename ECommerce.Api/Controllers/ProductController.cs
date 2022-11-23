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
        public ActionResult GetProducts()
        {
            var products = _productService.GetProducts();

            if(!products.Any()) {
                return NoContent();
            }

            return Ok(products);

        }

        [HttpGet]
        [Route("{productId}")]
        public ActionResult GetProduct([FromRoute] Guid productId)
        {
            var product = _productService.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

    }
}
