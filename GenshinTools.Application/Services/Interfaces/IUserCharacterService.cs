using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces;
public interface IUserCharacterService {
    Task AssociateCharacterToUser(string userId, int charId);
    Task DisassociateCharacterToUser(string userId, int charId);
    Task<List<Character>> GetUserCharacters(string userId);
    Task<List<Character>> GetUserCharactersFiltered(string userId);
}
