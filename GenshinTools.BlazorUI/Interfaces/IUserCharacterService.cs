using GenshinTools.BlazorUI.Models;

namespace GenshinTools.BlazorUI.Interfaces;

public interface IUserCharacterService {
    Task AssociateCharacterToUser(int userId, int charId);
    Task DisassociateCharacterToUser(int userId, int charId);
    Task<List<CharacterVM>> GetUserCharacters(int userId);
    Task<List<CharacterVM>> GetUserCharactersFiltered(int userId);
}
