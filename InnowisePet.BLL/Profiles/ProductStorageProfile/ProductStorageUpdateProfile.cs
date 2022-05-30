using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.ProductStorageProfile;

public class ProductStorageUpdateProfile : Profile
{
    public ProductStorageUpdateProfile()
    {
        CreateMap<ProductStorageUpdateDto, ProductStorage>()
            .ForMember(ps => ps.product_id, opt => opt.MapFrom(ps => ps.ProductId))
            .ForMember(ps => ps.storage_id, opt => opt.MapFrom(ps => ps.StorageId))
            .ForMember(ps => ps.quantity, opt => opt.MapFrom(ps => ps.Quantity));
    }
}