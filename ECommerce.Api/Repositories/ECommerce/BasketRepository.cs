using ECommerce.Api.Repositories.ECommerce.Data;
using ECommerce.Api.Repositories.ECommerce.Interfaces;
using ECommerce.Api.Repositories.ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Repositories.ECommerce
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ECommerceContext _context;
        public BasketRepository(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<Basket> GetBasketByBuyerId(Guid buyerId)
        {
            var basket = await _context.Baskets.AsNoTracking()
                .Include(i => i.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(x => x.BuyerId == buyerId);

            return basket;
        }

        public async Task<BasketItem> GetBasketItem(Guid basketId, Guid productId)
        {
            var item = await _context.BasketItems
                .Include(i => i.Basket)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(x => x.BasketId == basketId && x.ProductId == productId);

            return item;
        }

        public async Task<Basket> AddItemToBasket(Guid buyerId, Guid productId, int quantity)
        {
            var basket = await GetBasketByBuyerId(buyerId);

            if (basket == null)
            {
                basket = await CreateBasket();
            }

            var item = await GetBasketItem(basket.Id, productId);

            if(item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                var newItem = new BasketItem
                {
                    Id = Guid.NewGuid(),
                    BasketId = basket.Id,
                    ProductId = productId,
                    Quantity = quantity
                };

                await _context.BasketItems.AddAsync(newItem);
            }

            if(await _context.SaveChangesAsync() == 1)
            {
                return await GetBasketByBuyerId(buyerId);
            }

            return null;
        }

        public async Task<bool> RemoveItemFromBasket(Guid buyerId, Guid productId, int quantity)
        {
            var basket = await GetBasketByBuyerId(buyerId);

            if(basket != null)
            {
                var item = await GetBasketItem(basket.Id, productId);

                if (item != null)
                {
                    if(item.Quantity == 0)
                    {
                        _context.Remove(item);
                    }
                    else
                    {
                        item.Quantity -= quantity;
                    }

                    return await _context.SaveChangesAsync() == 1 ? true : false;
                }

                return false;
            }

            return false;
        }

        private async Task<Basket> CreateBasket()
        {
            var basket = new Basket
            {
                Id = Guid.NewGuid(),
                BuyerId = Guid.NewGuid()
            };

            await _context.Baskets.AddAsync(basket);

            return _context.SaveChanges() == 1 ? basket : null;
        }
    }
}
