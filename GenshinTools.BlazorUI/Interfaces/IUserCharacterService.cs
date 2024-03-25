using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Interfaces;

public interface IUserCharacterService {
    Task<Response<Guid>> AssociateCharacterToUser(string userId, int charId);
    Task<Response<Guid>> DisassociateCharacterToUser(string userId, int charId);
    Task<List<CharacterVM>> GetUserCharacters(string userId);
    Task<List<CharacterVM>> GetUserCharactersFiltered(string userId);
}
