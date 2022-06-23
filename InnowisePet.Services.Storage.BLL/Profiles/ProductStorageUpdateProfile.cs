using AutoMapper;
using InnowisePet.Services.Storage.BLL.DTO;
using InnowisePet.Services.Storage.DAL.Models;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class ProductStorageUpdateProfile : Profile
{
    public ProductStorageUpdateProfile()
    {
        CreateMap<ProductStorageUpdateDto, ProductStorage>();
    }
}