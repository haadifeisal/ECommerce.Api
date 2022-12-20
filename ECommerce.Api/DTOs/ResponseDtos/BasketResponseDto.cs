using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.DTOs.ResponseDtos
{
    public class BasketResponseDto
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public List<BasketItemResponseDto> Items { get; set; }
    }
}
