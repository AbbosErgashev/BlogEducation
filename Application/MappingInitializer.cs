using AutoMapper;
using BlogEducation.Domain;
using BlogEducation.Infrastructure;

namespace BlogEducation.Application;

public class MappingInitializer : Profile
{
    public MappingInitializer()
    {
        CreateMap<UserDTO, User>().ReverseMap();
        CreateMap<UserForCreationDTO, User>().ReverseMap();

        CreateMap<BlogDTO, Blog>().ReverseMap();
        CreateMap<BlogForCreationDTO, Blog>().ReverseMap();
    }
}
