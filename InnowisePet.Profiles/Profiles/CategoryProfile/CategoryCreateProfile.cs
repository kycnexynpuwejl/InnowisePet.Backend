using AutoMapper;
using InnowisePet.DTO.DTO.Category;
using InnowisePet.Models.Entities;

namespace InnowisePet.Profiles.Profiles.CategoryProfile;

public class CategoryCreateProfile : Profile
{
    public CategoryCreateProfile()
    {
        CreateMap<CategoryCreateDto, Category>()
            .ForMember(c => c.Id, opt => opt.MapFrom(c => Guid.NewGuid()));
    }
}