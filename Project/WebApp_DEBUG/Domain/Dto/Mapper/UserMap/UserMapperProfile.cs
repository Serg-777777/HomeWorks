using AutoMapper;
using WebApp_DEBUG.Domain.Model.UserModel;

namespace WebApp_DEBUG.Domain.Dto.Mapper.UserDtoMapper
{
    public class UserMapperProfile:Profile
    {
        public UserMapperProfile() 
        { 
            CreateMap<User, IDto>().ReverseMap();
        }
    }
}
