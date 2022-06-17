using AutoMapper;
using InnowisePet.DTO.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.ProductProfile;

public class ProductUpdateProfile : Profile
{
    public ProductUpdateProfile()
    {
        CreateMap<ProductUpdateDto, Product>()
            .ForMember(m => m.CategoryId, opt => opt.MapFrom(m => m.CategoryId))
            .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Title))
            .ForMember(m => m.Description, opt => opt.MapFrom(m => m.Description))
            .ForMember(m => m.Price, opt => opt.MapFrom(m => m.Price));
    }
}