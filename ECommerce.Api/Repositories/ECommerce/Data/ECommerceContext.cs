using ECommerce.Api.Repositories.ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Repositories.ECommerce.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
