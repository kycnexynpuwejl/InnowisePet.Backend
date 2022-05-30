using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles;

public class ProductCreateProfile : Profile
{
    public ProductCreateProfile()
    {
        CreateMap<ProductCreateDto, Product>()
            .ForMember(m => m.id, opt => opt.MapFrom(m => Guid.NewGuid()))
            .ForMember(m => m.category_id, opt => opt.MapFrom(m => m.CategoryId))
            .ForMember(m => m.title, opt => opt.MapFrom(m => m.Title))
            .ForMember(m => m.description, opt => opt.MapFrom(m => m.Description))
            .ForMember(m => m.price, opt => opt.MapFrom(m => m.Price));
    }
}