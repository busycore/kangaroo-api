using AutoMapper;
using kangaroo_api.Domains.Users.Models;

namespace kangaroo_api.Domains.Users.dtos;

public class AutoMapperProfile : Profile
{
 
    public AutoMapperProfile()
    {
        CreateMap<User, CreateUserDTO>();
        CreateMap<User, GetUserDTO>();
        CreateMap<GetUserDTO, User>();
        CreateMap<CreateUserDTO, User>();
    }
}