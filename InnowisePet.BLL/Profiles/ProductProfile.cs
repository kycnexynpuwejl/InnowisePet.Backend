using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(m => m.Title, opt => opt.MapFrom(m => m.Title))
            .ForMember(m => m.Description, opt => opt.MapFrom(m => m.Description))
            .ForMember(m => m.Price, opt => opt.MapFrom(m => m.Price))
            .ForMember(m => m.Quantity, opt => opt.MapFrom(m => m.Quantity))
            .ForMember(m => m.Id, opt => opt.MapFrom(m => m.Id))
            .ReverseMap();
    }
}