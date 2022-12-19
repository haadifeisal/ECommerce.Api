using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.Services.Interfaces
{
    public interface IBasketService
    {
        Task<Basket> GetBasket(Guid buyerId);
        Task<Basket> AddItemsToBasket(Guid buyerId, Guid productId, int quantity);
    }
}
