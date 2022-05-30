using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.ProductStorageProfile;

public class ProductStorageCreateProfile : Profile
{
    public ProductStorageCreateProfile()
    {
        CreateMap<ProductStorageCreateDto, ProductStorage>()
            .ForMember(ps => ps.id, opt => opt.MapFrom(ps => Guid.NewGuid()))
            .ForMember(ps => ps.product_id, opt => opt.MapFrom(ps => ps.ProductId))
            .ForMember(ps => ps.storage_id, opt => opt.MapFrom(ps => ps.StorageId))
            .ForMember(ps => ps.quantity, opt => opt.MapFrom(ps => ps.Quantity));
    }
}