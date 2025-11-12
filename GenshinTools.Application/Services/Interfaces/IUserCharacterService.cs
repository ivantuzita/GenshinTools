using GenshinTools.Application.DTOs;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces;
public interface IUserCharacterService {
    Task AssociateCharacterToUser(UserCharacterDTO model);
    Task DisassociateCharacterToUser(UserCharacterDTO model);
    Task<List<Character>> GetUserCharacters(string userId);
    Task<List<Character>> GetUserCharactersFiltered(string userId);
}
