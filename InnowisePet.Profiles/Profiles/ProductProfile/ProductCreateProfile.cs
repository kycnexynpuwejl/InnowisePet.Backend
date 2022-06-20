using AutoMapper;
using InnowisePet.DTO.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.ProductProfile;

public class ProductCreateProfile : Profile
{
    public ProductCreateProfile()
    {
        CreateMap<ProductCreateDto, Product>()
            .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()));
    }
}