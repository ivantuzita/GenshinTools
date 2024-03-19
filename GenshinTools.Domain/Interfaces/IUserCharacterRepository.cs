using GenshinTools.Domain.Models;

namespace GenshinTools.Domain.Interfaces;
public interface IUserCharacterRepository {
    Task AssociateCharacterToUser(string userId, int charId);
    Task DisassociateCharacterToUser(string userId, int charId);
    Task<List<Character>> GetUserCharacters(string userId);
    Task<List<Character>> GetUserCharactersFiltered(string userId);
    Task<bool> AlreadyAssociated(string userId, int charId);
}
