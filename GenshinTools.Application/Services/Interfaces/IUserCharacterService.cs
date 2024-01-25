using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces;
public interface IUserCharacterService {
    Task<List<UserCharacter>> GetItemsByUserId(int userId);
    Task<List<UserCharacter>> GetTodayItemsByUserId(int userId);
}
