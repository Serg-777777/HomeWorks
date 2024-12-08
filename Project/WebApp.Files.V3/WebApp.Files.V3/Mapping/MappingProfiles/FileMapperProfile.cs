
using Application.Mapping.DtoLogics.FileDtoLogics;
using Presentation.Mapping.DtoViews.FileDtoViews;
using AutoMapper;

namespace Presentation.Mapping.MappingProfiles;

public class FileMapperProfile:Profile
{
    public FileMapperProfile()
    {
        CreateMap<FileDtoLogic, FileDtoView>().ReverseMap();
    }
}
