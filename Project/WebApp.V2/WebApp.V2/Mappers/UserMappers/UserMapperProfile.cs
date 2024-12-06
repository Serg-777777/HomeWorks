using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Presentation.Mappers.DtoApps.UserDtoApps;


namespace Application.ServicesApps.Mappers.UserMappers;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserDtoLogic, UserDtoApp>().ReverseMap();
        CreateMap<UserProfileDtoLogic, UserProfileDtoApp>().ReverseMap();
        CreateMap<UserSettingDtoLogic, UserSettingDtoApp>().ReverseMap();

        CreateMap<UserModel, UserDtoLogic>().ReverseMap();
        CreateMap<UserProfileModel, UserProfileDtoLogic>().ReverseMap();
        CreateMap<UserSettingModel, UserSettingDtoLogic>().ReverseMap();

    }
}
