using AutoMapper;
using ECommerce.Api.DTOs.ResponseDtos;
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
        private readonly IMapper _mapper;
        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketResponseDto>> GetBasket()
        {
            var cookie = Request.Cookies["buyerId"];
            var buyerId = Guid.Empty;

            if (!String.IsNullOrEmpty(cookie))
            {
                buyerId = Guid.Parse(cookie);
            }

            var basket = await _basketService.GetBasket(buyerId);

            if (basket == null)
            {
                return NotFound();
            }

            var mappedBasket = _mapper.Map<BasketResponseDto>(basket);

            return Ok(mappedBasket);
        }

        [HttpPost]
        public async Task<ActionResult<BasketResponseDto>> AddItemToBasket(Guid productId, int quantity)
        {
            var cookie = Request.Cookies["buyerId"];
            var buyerId = Guid.Empty;

            if (!String.IsNullOrEmpty(cookie))
            {
                buyerId = Guid.Parse(cookie);
            }

            var basket = await _basketService.AddItemsToBasket(buyerId, productId, quantity);

            if (basket != null)
            {
                var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
                Response.Cookies.Append("buyerId", basket.BuyerId.ToString(), cookieOptions);

                var mappedBasket = _mapper.Map<BasketResponseDto>(basket);

                return CreatedAtRoute("GetBasket", mappedBasket);
            }

            return BadRequest(new ProblemDetails{Title = "Problem saving item to basket"});
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveItemFromBasket(Guid productId, int quantity)
        {
            var cookie = Request.Cookies["buyerId"];
            var buyerId = Guid.Empty;

            if (!String.IsNullOrEmpty(cookie))
            {
                buyerId = Guid.Parse(cookie);
            }

            var removedItem = await _basketService.RemoveItemFromBasket(buyerId, productId, quantity);

            if(removedItem == null)
            {
                return NotFound();
            }

            if(removedItem)
            {
                return Ok();
            }

            return BadRequest(new ProblemDetails { Title = "Problem removing item from the basket" });
        }

    }
}
