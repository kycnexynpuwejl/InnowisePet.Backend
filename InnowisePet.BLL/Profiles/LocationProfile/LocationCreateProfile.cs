using AutoMapper;
using InnowisePet.DTO.DTO.Location;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.LocationProfile;

public class LocationCreateProfile : Profile
{
    public LocationCreateProfile()
    {
        CreateMap<LocationCreateDto, Location>()
            .ForMember(c => c.City, opt => opt.MapFrom(c => c.City))
            .ForMember(c => c.Id, opt => opt.MapFrom(c => Guid.NewGuid()));
    }
}