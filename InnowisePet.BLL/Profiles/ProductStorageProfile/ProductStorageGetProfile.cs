using AutoMapper;
using InnowisePet.DTO.DTO.ProductStorage;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.ProductStorageProfile;

public class ProductStorageGetProfile : Profile
{
    public ProductStorageGetProfile()
    {
        CreateMap<ProductStorage, ProductStorageGetDto>()
            .ForMember(ps => ps.Id, opt => opt.MapFrom(ps => ps.id))
            .ForMember(ps => ps.ProductId, opt => opt.MapFrom(ps => ps.product_id))
            .ForMember(ps => ps.StorageId, opt => opt.MapFrom(ps => ps.storage_id))
            .ForMember(ps => ps.Quantity, opt => opt.MapFrom(ps => ps.quantity))
            .ForMember(ps => ps.ProductName, opt => opt.MapFrom(ps => ps.ProductName))
            .ForMember(ps => ps.StorageName, opt => opt.MapFrom(ps => ps.StorageName));
    }
}