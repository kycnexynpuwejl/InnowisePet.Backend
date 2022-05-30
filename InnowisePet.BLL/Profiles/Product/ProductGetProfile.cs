using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles;

public class ProductGetProfile : Profile
{
    public ProductGetProfile()
    {
        CreateMap<Product, ProductGetDto>()
            .ForMember(p => p.Title, opt => opt.MapFrom(p => p.title))
            .ForMember(p => p.Description, opt => opt.MapFrom(p => p.description))
            .ForMember(p => p.Price, opt => opt.MapFrom(p => p.price))
            .ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.CategoryName))
            .ForMember(p => p.Id, opt => opt.MapFrom(p => p.id));
    }
}