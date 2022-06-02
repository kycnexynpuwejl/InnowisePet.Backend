using AutoMapper;
using InnowisePet.Identity.Models;
using InnowisePet.Identity.Models.DTO;


namespace InnowisePet.Identity.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateUserMaps();
        }

        private void CreateUserMaps()
        {
            CreateMap<UserForCreationDto, AppUser>();
        }
    }
}
