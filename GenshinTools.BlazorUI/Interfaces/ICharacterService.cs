using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Interfaces;
public interface ICharacterService {
    Task<List<CharacterVM>> GetAllCharactersAsync();
    Task<CharacterVM> GetCharacterByIdAsync(int id);
}
