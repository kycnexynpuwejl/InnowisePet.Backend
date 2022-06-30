using AutoMapper;
using InnowisePet.Services.Product.BLL.DTO;
using InnowisePet.Services.Product.DAL.Models;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class ProductUpdateProfile : Profile
{
    public ProductUpdateProfile()
    {
        CreateMap<ProductUpdateDto, ProductModel>();
    }
}