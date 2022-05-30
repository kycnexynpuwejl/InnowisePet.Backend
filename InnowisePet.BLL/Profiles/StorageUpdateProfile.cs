using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles;

public class StorageUpdateProfile : Profile
{
    public StorageUpdateProfile()
    {
        CreateMap<StorageUpdateDto, Storage>()
            .ForMember(s => s.location_id, opt => opt.MapFrom(s => s.LocationId))
            .ForMember(s => s.title, opt => opt.MapFrom(s => s.Title));
    }
}