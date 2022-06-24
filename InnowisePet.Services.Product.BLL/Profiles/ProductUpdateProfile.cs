using AutoMapper;
using InnowisePet.Services.Product.BLL.DTO;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class ProductUpdateProfile : Profile
{
    public ProductUpdateProfile()
    {
        CreateMap<ProductUpdateDto, DAL.Product>();
    }
}