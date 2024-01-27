using AutoMapper;
using Okey.Application.UseCases.Users.Commands;
using Okey.Domain.DTOs.UsersDTO;
using Okey.Domain.Entities.Users;

namespace UserService.Application.Mappers;

public class UsersMapper : Profile
{
    public UsersMapper()
    {
        // Users
        CreateMap<User, CreateUserDTO>().ReverseMap();
        CreateMap<User, UpdateUserDTO>().ReverseMap();

        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();

        CreateMap<CreateUserDTO, CreateUserCommand>().ReverseMap();
        CreateMap<UpdateUserDTO, UpdateUserCommand>().ReverseMap();
    }
}
