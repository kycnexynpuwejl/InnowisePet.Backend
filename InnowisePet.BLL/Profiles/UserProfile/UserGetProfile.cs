using AutoMapper;
using InnowisePet.DTO.DTO.User;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.UserProfile;

public class UserGetProfile : Profile
{
    public UserGetProfile()
    {
        CreateMap<User, UserGetDto>()
            .ForMember(u => u.Id, opt => opt.MapFrom(u => u.id))
            .ForMember(u => u.Firstname, opt => opt.MapFrom(u => u.firstname))
            .ForMember(u => u.Lastname, opt => opt.MapFrom(u => u.lastname))
            .ForMember(u => u.Email, opt => opt.MapFrom(u => u.email))
            .ForMember(u => u.Mobile, opt => opt.MapFrom(u => u.mobile));
    }
}