using AutoMapper;
using InnowisePet.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class ProductCreateProfile : Profile
{
    public ProductCreateProfile()
    {
        CreateMap<ProductCreateDto, ProductModel>();
    }
}