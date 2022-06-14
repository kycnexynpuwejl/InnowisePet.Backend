using AutoMapper;
using InnowisePet.DTO.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.CategoryProfile;

public class CategoryCreateProfile : Profile
{
    public CategoryCreateProfile()
    {
        CreateMap<CategoryCreateDto, Category>()
            .ForMember(c => c.Title, opt => opt.MapFrom(c => c.Title))
            .ForMember(c => c.Id, opt => opt.MapFrom(c => Guid.NewGuid()));
    }
}