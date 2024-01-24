using AutoMapper;
using GenshinTools.Application.DTOs;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.MappingProfiles;

public class WeaponProfile : Profile {
    public WeaponProfile() {
        CreateMap<WeaponDTO, Weapon>().ReverseMap();
    }
}
