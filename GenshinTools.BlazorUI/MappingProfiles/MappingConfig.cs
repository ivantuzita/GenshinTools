using AutoMapper;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CharacterDTO, CharacterVM>().ReverseMap();
            CreateMap<Character, CharacterVM>().ReverseMap();
            CreateMap<WeaponDTO, WeaponVM>().ReverseMap();
            CreateMap<Weapon, WeaponVM>().ReverseMap();
        }
    }
}
