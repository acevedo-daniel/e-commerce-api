using e_commerce_api.Models;
using e_commerce_api.DTOs.ProductImages;
using AutoMapper;
namespace e_commerce_api.Mappers
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageResponseDto>();
        }
    }
}
