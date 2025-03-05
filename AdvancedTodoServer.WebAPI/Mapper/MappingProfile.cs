using AdvancedTodoServer.WebAPI.DTOs;
using AdvancedTodoServer.WebAPI.Models;
using AutoMapper;

namespace AdvancedTodoServer.WebAPI.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, User>();

        CreateMap<UpdateUserDto, User>();

        CreateMap<CreateTodoDto, Todo>();
        CreateMap<UpdateTodoDto, Todo>();
    }
}
