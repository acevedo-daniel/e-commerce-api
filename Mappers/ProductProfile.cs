using AutoMapper;
using e_commerce_api.Models;
using e_commerce_api.DTOs.ProductCategories;
using e_commerce_api.DTOs.Product;
using e_commerce_api.DTOs.ProductImages;

namespace e_commerce_api.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src =>
                src.ImageUrls.Select(url => new ProductImage { Url = url, Product = null, AltText = "", Order = 0 }).ToList()
                ))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<Product, ProductResponseDto>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
               .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
        }
    }
}