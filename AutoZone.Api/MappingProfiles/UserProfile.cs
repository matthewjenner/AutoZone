using AutoZone.Domain.Models;
using AutoZone.Api.Dtos;
using AutoMapper;

namespace AutoZone.Api.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}
