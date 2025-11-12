using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using GenshinTools.Domain.Common.Helpers;

namespace GenshinTools.Persistence.Repositories;

public class UserWeaponRepository : IUserWeaponRepository
{
    protected readonly GenshinDatabaseContext _context;

    public UserWeaponRepository(GenshinDatabaseContext context) {
        _context = context;
    }

    public async Task<bool> AlreadyAssociated(string userId, int weaponId) {
        return await (from uw in _context.UserWeapons
                      where uw.UserId == userId && uw.WeaponId == uw.WeaponId
                      select uw).AnyAsync();
    }

    public async Task AssociateWeaponToUser(string userId, int weaponId)
    {
        UserWeapon userWeapon = new UserWeapon { UserId = userId, WeaponId = weaponId };
        await _context.AddAsync(userWeapon);
        await _context.SaveChangesAsync();
    }

    public async Task DisassociateWeaponToUser(string userId, int weaponId) {
        var obj = await (from uw in _context.UserWeapons
                         where uw.UserId == userId
                         where uw.WeaponId == weaponId
                         select uw).FirstOrDefaultAsync();

        if (obj != null) {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Weapon>> GetUserWeapons(string userId) {
        var weapons = await (from uw in _context.UserWeapons
                              join w in _context.Weapons on uw.WeaponId equals w.Id
                              where uw.UserId == userId
                              select w).ToListAsync();
        return weapons;
    }

    public async Task<List<Weapon>> GetUserWeaponsFiltered(string userId) {
        var weapons = await GetUserWeapons(userId);

        //selects todays weapons
        var filter = (from w in weapons
                      let days = w.WeekDays.Split(',').Select(x => int.Parse(x))
                      where days.Contains(DateHelper.GetCurrentDayOfWeek())
                      select w).ToList();

        return filter;
    }
}
