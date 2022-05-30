using AutoMapper;
using InnowisePet.DTO.DTO.User;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.UserProfile;

public class UserCreateProfile : Profile
{
    public UserCreateProfile()
    {
        CreateMap<UserCreateDto, User>()
            .ForMember(u => u.id, opt => opt.MapFrom(u => Guid.NewGuid()))
            .ForMember(u => u.firstname, opt => opt.MapFrom(u => u.Firstname))
            .ForMember(u => u.lastname, opt => opt.MapFrom(u => u.Lastname))
            .ForMember(u => u.email, opt => opt.MapFrom(u => u.Email))
            .ForMember(u => u.mobile, opt => opt.MapFrom(u => u.Mobile))
            .ForMember(u => u.password_hash, opt => opt.MapFrom(u => u.PasswordHash));
    }
}