using AutoMapper;
using InnowisePet.DTO.DTO.Order;
using InnowisePet.Models.Entities;

namespace InnowisePet.BLL.Profiles.OrderProfile;

public class OrderGetProfile : Profile
{
    public OrderGetProfile()
    {
        CreateMap<Order, OrderGetDto>()
            .ForMember(p => p.Id, opt => opt.MapFrom(p => p.id))
            .ForMember(p => p.Firstname, opt => opt.MapFrom(p => p.firstname))
            .ForMember(p => p.Lastname, opt => opt.MapFrom(p => p.lastname))
            .ForMember(p => p.Address, opt => opt.MapFrom(p => p.address))
            .ForMember(p => p.City, opt => opt.MapFrom(p => p.city))
            .ForMember(p => p.Country, opt => opt.MapFrom(p => p.country));
    }
}