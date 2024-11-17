using AutoMapper;
using WebApp_DEBUG.Domain.Model.UserModel;
using WebApp_DEBUG.Logic.Dto;

namespace WebApp_DEBUG.Logic.Dto.Mapper.UserMap
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, IDto>().ReverseMap();
        }
    }
}
