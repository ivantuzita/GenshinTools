using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace GenshinTools.Persistence.Repositories;

public class UserCharacterRepository : IUserCharacterRepository
{
    protected readonly GenshinDatabaseContext _context;

    public UserCharacterRepository(GenshinDatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AlreadyAssociated(int userId, int charId)
    {
        return await _context.UserCharacters.AnyAsync(x => x.UserId == userId && x.CharacterId == charId);
    }

    public async Task AssociateCharacterToUser(int userId, int charId)
    {
        var userChar = new {userId, charId};
        await _context.AddAsync(userChar);
        await _context.SaveChangesAsync();
    }

    public async Task DisassociateCharacterToUser(int userId, int charId)
    {
        // not sure if most efficient way
        var obj = await _context.UserCharacters.Where(q => q.UserId == userId
            && q.CharacterId == charId).FirstOrDefaultAsync();

        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Character>> GetUserCharacters(int userId)
    {
        var userChars = await _context.UserCharacters
            .Where(q => q.UserId == userId)
            .Select(x => x.CharacterId)
            .ToListAsync();

        // not sure if this is correct or the most efficient way to do this.
        var chars = await _context.Characters.Where(x => userChars.Contains(x.Id)).ToListAsync();

        return chars;
    }

    public async Task<List<Character>> GetUserCharactersFiltered(int userId)
    {
        var chars = await GetUserCharacters(userId);
        // not sure if this is correct or the most efficient way to do this.
        var filter = chars.Where(y => y.WeekDays.Contains(dayOfWeek())).ToList();
        return filter;
    }

    private int dayOfWeek()
    {
        return ((int)DateTime.Now.DayOfWeek + 6) % 7;
    }

}
