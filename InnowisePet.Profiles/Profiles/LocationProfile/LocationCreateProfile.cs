using AutoMapper;
using InnowisePet.DTO.DTO.Location;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.LocationProfile;

public class LocationCreateProfile : Profile
{
    public LocationCreateProfile()
    {
        CreateMap<LocationCreateDto, Location>()
            .ForMember(l => l.Id, opt => opt.MapFrom(l => Guid.NewGuid()))
            .ForMember(l => l.City, opt => opt.MapFrom(l => l.City));
    }
}