using GenshinTools.Domain.Models;

namespace GenshinTools.Domain.Interfaces;
public interface IUserCharacterRepository {
    Task AssociateCharacterToUser(int userId, int charId);
    Task DisassociateCharacterToUser(int userId, int charId);
    Task<List<Character>> GetUserCharacters(int userId);
    Task<List<Character>> GetUserCharactersFiltered(int userId);
    Task<bool> AlreadyAssociated(int userId, int charId);
}
