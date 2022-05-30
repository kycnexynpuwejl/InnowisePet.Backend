using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.StorageProfile;

public class StorageGetProfile : Profile
{
    public StorageGetProfile()
    {
        CreateMap<Storage, StorageGetDto>()
            .ForMember(s => s.Id, opt => opt.MapFrom(s => s.id))
            .ForMember(s => s.LocationId, opt => opt.MapFrom(s => s.location_id))
            .ForMember(s => s.Title, opt => opt.MapFrom(s => s.title))
            .ForMember(s => s.LocationName, opt => opt.MapFrom(s => s.LocationName));
    }
}