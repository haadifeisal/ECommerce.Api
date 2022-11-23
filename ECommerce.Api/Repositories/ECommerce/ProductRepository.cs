using ECommerce.Api.Repositories.ECommerce.Data;
using ECommerce.Api.Repositories.ECommerce.Interfaces;
using ECommerce.Api.Repositories.ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Repositories.ECommerce
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceContext _context;

        public ProductRepository(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();

            return products;
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
            {
                return null;
            }

            return product;
        }

    }
}
