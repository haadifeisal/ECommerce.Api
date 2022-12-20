using ECommerce.Api.Repositories.ECommerce.Interfaces;
using ECommerce.Api.Repositories.ECommerce.Models;
using ECommerce.Api.Services.Interfaces;

namespace ECommerce.Api.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<Basket> GetBasket(Guid buyerId)
        {
            var basket = await _basketRepository.GetBasketByBuyerId(buyerId);

            return basket;
        }

        public async Task<Basket> AddItemsToBasket(Guid buyerId, Guid productId, int quantity)
        {
            var basket = await _basketRepository.AddItemToBasket(buyerId, productId, quantity);

            return basket;
        }

        public async Task<bool> RemoveItemFromBasket(Guid buyerId, Guid productId, int quantity)
        {
            var removedItem = await _basketRepository.RemoveItemFromBasket(buyerId, productId, quantity);

            return removedItem;
        }
    }
}
