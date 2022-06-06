using AutoMapper;
using InnowisePet.DTO.DTO.Order;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.OrderProfile;

public class OrderUpdateProfile : Profile
{
    public OrderUpdateProfile()
    {
        CreateMap<OrderUpdateDto, Order>()
            .ForMember(p => p.id, opt => opt.MapFrom(p => Guid.NewGuid()))
            .ForMember(p => p.firstname, opt => opt.MapFrom(p => p.Firstname))
            .ForMember(p => p.lastname, opt => opt.MapFrom(p => p.Lastname))
            .ForMember(p => p.address, opt => opt.MapFrom(p => p.Address))
            .ForMember(p => p.city, opt => opt.MapFrom(p => p.City))
            .ForMember(p => p.country, opt => opt.MapFrom(p => p.Country));
    }
}