using AutoMapper;
using InnowisePet.DTO.DTO.Product;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Product.BLL.Profiles;

public class ProductGetProfile : Profile
{
    public ProductGetProfile()
    {
        CreateMap<ProductModel, ProductGetDto>();
    }
}