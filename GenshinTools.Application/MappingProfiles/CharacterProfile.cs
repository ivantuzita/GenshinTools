using AutoMapper;
using GenshinTools.Application.DTOs;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.MappingProfiles;

public class CharacterProfile : Profile {
    public CharacterProfile() {
        CreateMap<CharacterDTO, Character>().ReverseMap();
    }
}
