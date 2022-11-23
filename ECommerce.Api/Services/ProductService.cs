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

        public IEnumerable<Product> GetProducts() {

            var products = _productRepository.GetProducts();

            return products;
        }

        public Product GetProduct(Guid productId)
        {

            var product = _productRepository.GetProduct(productId);

            return product;
        }

    }
}
