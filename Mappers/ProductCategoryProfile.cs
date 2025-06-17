using AutoMapper;
using e_commerce_api.Models;
using e_commerce_api.DTOs.ProductCategories;

namespace e_commerce_api.Mappers
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProducCategoryResponseDto>();
        }
    }
}