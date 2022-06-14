using AutoMapper;
using InnowisePet.DTO.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.StorageProfile;

public class StorageCreateProfile : Profile
{
    public StorageCreateProfile()
    {
        CreateMap<StorageCreateDto, Storage>()
            .ForMember(s => s.id, opt => opt.MapFrom(s => Guid.NewGuid()))
            .ForMember(s => s.location_id, opt => opt.MapFrom(s => s.LocationId))
            .ForMember(s => s.title, opt => opt.MapFrom(s => s.Title));
    }
}