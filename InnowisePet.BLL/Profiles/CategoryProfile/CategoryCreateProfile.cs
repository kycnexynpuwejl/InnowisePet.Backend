using AutoMapper;
using InnowisePet.DTO.DTO;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.CategoryProfile;

public class CategoryCreateProfile : Profile
{
    public CategoryCreateProfile()
    {
        CreateMap<CategoryCreateDto, Category>()
            .ForMember(c => c.title, opt => opt.MapFrom(c => c.Title))
            .ForMember(c => c.id, opt => opt.MapFrom(c => Guid.NewGuid()));
    }
}