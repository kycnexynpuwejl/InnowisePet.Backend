using AutoMapper;
using InnowisePet.Services.Product.BLL.DTO;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class ProductCreateProfile : Profile
{
    public ProductCreateProfile()
    {
        CreateMap<ProductCreateDto, DAL.Product>();
    }
}