using ECommerce.Api.Repositories.ECommerce.Interfaces;
using ECommerce.Api.Repositories.ECommerce.Models;
using ECommerce.Api.Services.Interfaces;

namespace ECommerce.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts() {

            var products = await _productRepository.GetProducts();

            return products;
        }

        public async Task<Product> GetProduct(Guid productId)
        {

            var product = await _productRepository.GetProduct(productId);

            return product;
        }

    }
}
