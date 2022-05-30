using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles;

public class ProductUpdateProfile : Profile
{
    public ProductUpdateProfile()
    {
        CreateMap<ProductUpdateDto, Product>()
            .ForMember(m => m.category_id, opt => opt.MapFrom(m => m.CategoryId))
            .ForMember(m => m.title, opt => opt.MapFrom(m => m.Title))
            .ForMember(m => m.description, opt => opt.MapFrom(m => m.Description))
            .ForMember(m => m.price, opt => opt.MapFrom(m => m.Price));
    }
}