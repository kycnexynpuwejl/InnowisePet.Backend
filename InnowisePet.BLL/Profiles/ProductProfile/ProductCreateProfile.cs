using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.DTO.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.ProductProfile;

public class ProductCreateProfile : Profile
{
    public ProductCreateProfile()
    {
        CreateMap<ProductCreateDto, Product>()
            .ForMember(p => p.id, opt => opt.MapFrom(p => Guid.NewGuid()))
            .ForMember(p => p.category_id, opt => opt.MapFrom(p => p.CategoryId))
            .ForMember(p => p.title, opt => opt.MapFrom(p => p.Title))
            .ForMember(p => p.description, opt => opt.MapFrom(p => p.Description))
            .ForMember(p => p.price, opt => opt.MapFrom(p => p.Price));
    }
}