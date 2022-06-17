using AutoMapper;
using InnowisePet.DTO.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.StorageProfile;

public class StorageUpdateProfile : Profile
{
    public StorageUpdateProfile()
    {
        CreateMap<StorageUpdateDto, Storage>()
            .ForMember(s => s.LocationId, opt => opt.MapFrom(s => s.LocationId))
            .ForMember(s => s.Title, opt => opt.MapFrom(s => s.Title));
    }
}