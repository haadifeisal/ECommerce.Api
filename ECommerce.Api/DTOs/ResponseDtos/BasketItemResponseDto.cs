using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.DTOs.ResponseDtos
{
    public class BasketItemResponseDto
    {
        public int Quantity { get; set; }
        public ProductResponseDto Product { get; set; }
    }
}
