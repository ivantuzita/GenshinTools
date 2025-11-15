using GenshinTools.Domain.Common.Helpers;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace GenshinTools.Persistence.Repositories;

public class UserCharacterRepository : IUserCharacterRepository {
    protected readonly GenshinDatabaseContext _context;

    public UserCharacterRepository(GenshinDatabaseContext context) {
        _context = context;
    }

    public async Task<bool> AlreadyAssociated(string userId, int charId) {
        return await (from uc in _context.UserCharacters
                      where uc.UserId == userId && uc.CharacterId == uc.CharacterId
                      select uc).AnyAsync();
    }

    public async Task AssociateCharacterToUser(string userId, int charId) {
        var userChar = new UserCharacter { UserId = userId, CharacterId = charId };
        await _context.AddAsync(userChar);
        await _context.SaveChangesAsync();
    }

    public async Task DisassociateCharacterToUser(string userId, int charId) {
        var obj = await (from uc in _context.UserCharacters
                         where uc.UserId == userId
                         where uc.CharacterId == charId
                         select uc).FirstOrDefaultAsync();

        if (obj != null) {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Character>> GetUserCharacters(string userId) {
        var userChars = await (from uc in _context.UserCharacters
                               join c in _context.Characters on uc.CharacterId equals c.Id
                               where uc.UserId == userId
                               select c).ToListAsync();

        return userChars;
    }

    public async Task<List<Character>> GetUserCharactersFiltered(string userId) {
        var chars = await GetUserCharacters(userId);
        var filter = (from c in chars
                      join tm in _context.TalentMaterials on c.Id equals tm.Id
                      let days = tm.WeekDays.Split(',').Select(x => int.Parse(x))
                      where days.Contains(DateHelper.GetCurrentDayOfWeek())
                      select c).ToList();

        return filter;
    }
}
