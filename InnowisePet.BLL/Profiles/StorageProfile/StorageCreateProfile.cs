using AutoMapper;
using InnowisePet.DTO.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.StorageProfile;

public class StorageCreateProfile : Profile
{
    public StorageCreateProfile()
    {
        CreateMap<StorageCreateDto, Storage>()
            .ForMember(s => s.Id, opt => opt.MapFrom(s => Guid.NewGuid()))
            .ForMember(s => s.LocationId, opt => opt.MapFrom(s => s.LocationId))
            .ForMember(s => s.Title, opt => opt.MapFrom(s => s.Title));
    }
}