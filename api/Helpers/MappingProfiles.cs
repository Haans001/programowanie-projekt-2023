using api.Models.Dto.Class;
using api.Models.Entities;
using AutoMapper;

namespace api.Helpers;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        #region Class
        CreateMap<Class, GetClassDto>();
        CreateMap<CreateClassDto, Class>();
        CreateMap<UpdateClassDto, Class>();
        CreateMap<GetClassDto, Class>();
        #endregion



    }
}