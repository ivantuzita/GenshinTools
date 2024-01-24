using AutoMapper;
using GenshinTools.Application.DTOs;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.MappingProfiles;
public class UserProfile : Profile {
    public UserProfile()
    {
        CreateMap<UserDTO, User>().ReverseMap();
    }
}
