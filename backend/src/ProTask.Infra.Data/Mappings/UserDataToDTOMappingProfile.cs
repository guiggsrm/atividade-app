using AutoMapper;
using ProTask.Infra.Data.DTO;
using ProTask.Infra.Data.Identity;

namespace ProTask.Infra.Data.Mappings
{
    public class UserDataToDTOMappingProfile : Profile
    {
        public UserDataToDTOMappingProfile()
        {
            //CreateMap<ApplicationUser, UserDTO>();
        }
    }
}