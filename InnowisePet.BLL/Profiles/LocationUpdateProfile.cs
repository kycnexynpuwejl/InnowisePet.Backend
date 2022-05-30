using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles;

public class LocationUpdateProfile : Profile
{
    public LocationUpdateProfile()
    {
        CreateMap<LocationUpdateDto, Location>()
            .ForMember(l => l.city, opt => opt.MapFrom(l => l.City));
    }
}