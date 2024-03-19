using GenshinTools.BlazorUI.Models;

namespace GenshinTools.BlazorUI.Interfaces;

public interface IUserCharacterService {
    Task AssociateCharacterToUser(string userId, int charId);
    Task DisassociateCharacterToUser(string userId, int charId);
    Task<List<CharacterVM>> GetUserCharacters(string userId);
    Task<List<CharacterVM>> GetUserCharactersFiltered(string userId);
}
