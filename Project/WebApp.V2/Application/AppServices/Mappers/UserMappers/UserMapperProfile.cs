using Application.DtoApps.UserDtoApps;
using AutoMapper;
using Domain.Models;
using Infrastructure.DtoLogics.UserDtoLogics;


namespace Application.ServicesApps.Mappers.UserMappers;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<IUserDtoLogic, IUserDtoApp>().ReverseMap();
        CreateMap<IEntity, IUserDtoLogic>().ReverseMap();
    }
}
