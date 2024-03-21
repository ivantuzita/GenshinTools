using AutoMapper;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Character, CharacterVM>().ReverseMap();
            CreateMap<Weapon, WeaponVM>().ReverseMap();
        }
    }
}
