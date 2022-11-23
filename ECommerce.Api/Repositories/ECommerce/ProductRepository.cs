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

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products.AsNoTracking().ToList();

            return products;
        }

        public Product GetProduct(Guid productId)
        {
            var product = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == productId);

            if(product == null)
            {
                return null;
            }

            return product;
        }

    }
}
