using AutoMapper;
using InnowisePet.DTO.DTO.Storage;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class StorageCreateProfile : Profile
{
    public StorageCreateProfile()
    {
        CreateMap<StorageCreateDto, Models.Entities.Storage>();
    }
}