using AutoMapper;
using ProductApp.Application.Dtos.CategoryDtos;
using ProductApp.Application.Dtos.ProductDtos;
using ProductApp.Domain.Categories.Entities;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Mapping
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile() 
        {
            CreateMap<Product, ProductDto>()
                .ForMember
                (
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null)
                );

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ProductNames, opt => opt.MapFrom(src => src.Products.Select(x=>x.Title).ToList()));
        }
    }
}
