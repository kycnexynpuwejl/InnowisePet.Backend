using AutoMapper;
using InnowisePet.DTO.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.CategoryProfile;

public class CategoryUpdateProfile : Profile
{
    public CategoryUpdateProfile()
    {
        CreateMap<CategoryUpdateDto, Category>()
            .ForMember(c => c.title, opt => opt.MapFrom(c => c.Title));
    }
}