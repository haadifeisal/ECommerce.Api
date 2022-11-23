﻿using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.Repositories.ECommerce.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(Guid productId);
    }
}
