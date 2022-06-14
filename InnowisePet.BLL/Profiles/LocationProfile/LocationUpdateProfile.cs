using AutoMapper;
using InnowisePet.DTO.DTO.Location;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.LocationProfile;

public class LocationUpdateProfile : Profile
{
    public LocationUpdateProfile()
    {
        CreateMap<LocationUpdateDto, Location>()
            .ForMember(l => l.city, opt => opt.MapFrom(l => l.City));
    }
}