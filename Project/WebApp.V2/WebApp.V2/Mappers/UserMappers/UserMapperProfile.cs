using Application.DtoLogics.UserDtoLogics;
using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Presentation.Mappers.DtoApps.UserDtoViews;
using Presentation.Mappers.DtoViews.UserDtoViews;


namespace Application.ServicesApps.Mappers.UserMappers;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserModel, UserDtoLogic>().ReverseMap();
        CreateMap<UserDtoLogic, UserDtoView>().ReverseMap();
        CreateMap<UserModel, UserIdDtoLogic>().ReverseMap();
        CreateMap<UserIdDtoLogic, UserIdDtoView>().ReverseMap();

    }
}
