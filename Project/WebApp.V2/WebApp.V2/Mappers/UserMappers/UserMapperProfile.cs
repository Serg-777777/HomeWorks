using Application.DtoLogics.UserDtoLogics;
using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;
using Presentation.Mappers.DtoViews.UserDtoViews;


namespace Application.ServicesViews.Mappers.UserMappers;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        base.AllowNullCollections=true;

        CreateMap<UserModel, UserDtoLogic>().ReverseMap();
        CreateMap<UserDtoLogic, UserDtoView>().ReverseMap();

        CreateMap<UserModel, UserFullDtoLogic>().ReverseMap();
        CreateMap<UserFullDtoLogic, UserFullDtoView>().ReverseMap();

        CreateMap<UserProfileModel, UserProfileDtoLogic>().ReverseMap();
        CreateMap<UserProfileDtoLogic, UserProfileDtoView>().ReverseMap();
    }
}
