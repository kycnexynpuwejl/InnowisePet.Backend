using AutoMapper;
using InnowisePet.DTO.DTO.ProductStorage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.ProductStorageProfile;

public class ProductStorageUpdateProfile : Profile
{
    public ProductStorageUpdateProfile()
    {
        CreateMap<ProductStorageUpdateDto, ProductStorage>()
            .ForMember(ps => ps.ProductId, opt => opt.MapFrom(ps => ps.ProductId))
            .ForMember(ps => ps.StorageId, opt => opt.MapFrom(ps => ps.StorageId))
            .ForMember(ps => ps.Quantity, opt => opt.MapFrom(ps => ps.Quantity));
    }
}