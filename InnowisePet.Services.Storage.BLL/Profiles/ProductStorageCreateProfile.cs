using AutoMapper;
using InnowisePet.DTO.DTO.ProductStorage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class ProductStorageCreateProfile : Profile
{
    public ProductStorageCreateProfile()
    {
        CreateMap<ProductStorageCreateDto, ProductStorage>();
    }
}