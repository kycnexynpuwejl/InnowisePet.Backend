using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles;

public class ProductGetProfile : Profile
{
    public ProductGetProfile()
    {
        CreateMap<Product, ProductGetDto>()
            .ForMember(m => m.Title, opt => opt.MapFrom(m => m.title))
            .ForMember(m => m.Description, opt => opt.MapFrom(m => m.description))
            .ForMember(m => m.Price, opt => opt.MapFrom(m => m.price))
            .ForMember(m => m.CategoryName, opt => opt.MapFrom(m => m.category_id))
            .ForMember(m => m.Id, opt => opt.MapFrom(m => m.id));
    }
}