using AutoMapper;
using ECommerce.Api.DTOs.ResponseDtos;
using ECommerce.Api.Repositories.ECommerce.Models;

namespace ECommerce.Api.DTOs.Configuration
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            // Response Dtos
            CreateMap<Product, ProductResponseDto>();
            CreateMap<BasketItem, BasketItemResponseDto>();
            CreateMap<Basket, BasketResponseDto>()
                .ForMember(x => x.Items, y => y.MapFrom(z => z.Items));

            // Request Dtos
        }
    }
}
