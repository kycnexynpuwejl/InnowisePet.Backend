using AutoMapper;
using InnowisePet.DTO.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.StorageProfile;

public class StorageGetProfile : Profile
{
    public StorageGetProfile()
    {
        CreateMap<Storage, StorageGetDto>()
            .ForMember(s => s.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(s => s.LocationId, opt => opt.MapFrom(s => s.LocationId))
            .ForMember(s => s.Title, opt => opt.MapFrom(s => s.Title))
            .ForMember(s => s.LocationName, opt => opt.MapFrom(s => s.LocationName));
    }
}