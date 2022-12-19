using ECommerce.Api.Services;
using ECommerce.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult> GetBasket()
        {
            var buyerId = Guid.Parse(Request.Cookies["buyerId"].ToString());
            var basket = await _basketService.GetBasket(buyerId);

            if (basket == null)
            {
                return NotFound();
            }

            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult> AddItemToBasket(Guid productId, int quantity)
        {
            var buyerId = Guid.Parse(Request.Cookies["buyerId"].ToString());

            var basket = await _basketService.AddItemsToBasket(buyerId, productId, quantity);
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("buyerId", basket.BuyerId.ToString(), cookieOptions);

            if (basket != null)
            {
                return StatusCode(201);
            }

            return BadRequest(new ProblemDetails{Title = "Problem saving item to basket"});
        }

        /*[HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
        {
            
            return Ok();
        }*/

    }
}
