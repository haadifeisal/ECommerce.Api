using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(Guid productId);
    }
}
