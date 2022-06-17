using AutoMapper;
using InnowisePet.DTO.DTO.ProductStorage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.ProductStorageProfile;

public class ProductStorageCreateProfile : Profile
{
    public ProductStorageCreateProfile()
    {
        CreateMap<ProductStorageCreateDto, ProductStorage>()
            .ForMember(ps => ps.Id, opt => opt.MapFrom(ps => Guid.NewGuid()))
            .ForMember(ps => ps.ProductId, opt => opt.MapFrom(ps => ps.ProductId))
            .ForMember(ps => ps.StorageId, opt => opt.MapFrom(ps => ps.StorageId))
            .ForMember(ps => ps.Quantity, opt => opt.MapFrom(ps => ps.Quantity));
    }
}