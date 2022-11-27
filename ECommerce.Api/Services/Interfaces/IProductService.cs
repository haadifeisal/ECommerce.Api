using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProduct(Guid productId);
    }
}
