using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.Repositories.ECommerce.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(Guid productId);
    }
}
