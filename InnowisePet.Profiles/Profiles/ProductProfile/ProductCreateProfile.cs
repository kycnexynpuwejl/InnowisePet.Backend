using AutoMapper;
using InnowisePet.DTO.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.ProductProfile;

public class ProductCreateProfile : Profile
{
    public ProductCreateProfile()
    {
        CreateMap<ProductCreateDto, Product>()
            .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()))
            .ForMember(p => p.CategoryId, opt => opt.MapFrom(p => p.CategoryId))
            .ForMember(p => p.Title, opt => opt.MapFrom(p => p.Title))
            .ForMember(p => p.Description, opt => opt.MapFrom(p => p.Description))
            .ForMember(p => p.Price, opt => opt.MapFrom(p => p.Price));
    }
}