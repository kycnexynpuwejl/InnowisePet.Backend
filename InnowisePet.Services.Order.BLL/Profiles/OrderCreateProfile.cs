using AutoMapper;
using InnowisePet.DTO.DTO.Order;

namespace InnowisePet.Services.Order.BLL.Profiles;

public class OrderCreateProfile : Profile
{
    public OrderCreateProfile()
    {
        CreateMap<OrderCreateDto, DAL.Order>()
            .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()))
            .ForMember(p => p.Firstname, opt => opt.MapFrom(p => p.Firstname))
            .ForMember(p => p.Lastname, opt => opt.MapFrom(p => p.Lastname))
            .ForMember(p => p.Address, opt => opt.MapFrom(p => p.Address))
            .ForMember(p => p.City, opt => opt.MapFrom(p => p.City))
            .ForMember(p => p.Country, opt => opt.MapFrom(p => p.Country));
    }
}