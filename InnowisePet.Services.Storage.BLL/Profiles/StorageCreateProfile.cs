using AutoMapper;
using InnowisePet.Services.Storage.BLL.DTO;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class StorageCreateProfile : Profile
{
    public StorageCreateProfile()
    {
        CreateMap<StorageCreateDto, DAL.Models.Storage>();
    }
}