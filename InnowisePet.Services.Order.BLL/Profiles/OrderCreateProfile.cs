using AutoMapper;
using InnowisePet.DTO.DTO.Order;

namespace InnowisePet.Services.Order.BLL.Profiles;

public class OrderCreateProfile : Profile
{
    public OrderCreateProfile()
    {
        CreateMap<OrderCreateDto, DAL.Order>()
            .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()));
    }
}