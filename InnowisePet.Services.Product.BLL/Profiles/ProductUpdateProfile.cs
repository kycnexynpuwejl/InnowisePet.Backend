using AutoMapper;
using InnowisePet.DTO.DTO.Product;
using InnowisePet.Services.Product.DAL.Models;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class ProductUpdateProfile : Profile
{
    public ProductUpdateProfile()
    {
        CreateMap<ProductUpdateDto, ProductModel>();
    }
}