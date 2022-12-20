using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.Repositories.ECommerce.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketByBuyerId(Guid buyerId);
        Task<BasketItem> GetBasketItem(Guid basketId, Guid productId);
        Task<Basket> AddItemToBasket(Guid buyerId, Guid productId, int quantity);
        Task<bool> RemoveItem(Guid buyerId, Guid productId, int quantity);
    }
}
