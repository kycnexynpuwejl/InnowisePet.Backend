using AutoMapper;
using InnowisePet.DTO.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.CategoryProfile;

public class CategoryUpdateProfile : Profile
{
    public CategoryUpdateProfile()
    {
        CreateMap<CategoryUpdateDto, Category>()
            .ForMember(c => c.Title, opt => opt.MapFrom(c => c.Title));
    }
}