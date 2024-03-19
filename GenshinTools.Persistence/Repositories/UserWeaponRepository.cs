using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace GenshinTools.Persistence.Repositories;

public class UserWeaponRepository : IUserWeaponRepository
{
    private readonly GenshinDatabaseContext _context;

    public UserWeaponRepository(GenshinDatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AlreadyAssociated(string userId, int weaponId)
    {
        return await _context.UserWeapons.AnyAsync(x => x.UserId == userId && x.WeaponId == weaponId);
    }

    public async Task AssociateWeaponToUser(string userId, int weaponId)
    {
        var userWeapon = new { userId, weaponId };
        await _context.AddAsync(userWeapon);
        await _context.SaveChangesAsync();
    }

    public async Task DisassociateWeaponToUser(string userId, int weaponId)
    {
        // not sure if most efficient way
        var obj = await _context.UserWeapons.Where(q => q.UserId == userId
            && q.WeaponId == weaponId).FirstOrDefaultAsync();

        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Weapon>> GetUserWeapons(string userId)
    {
        var userWeapons = await _context.UserWeapons
            .Where(q => q.UserId == userId)
            .Select(x => x.WeaponId)
            .ToListAsync();

        // not sure if this is correct or the most efficient way to do this.
        var weapons = await _context.Weapons.Where(x => userWeapons.Contains(x.Id)).ToListAsync();

        return weapons;
    }

    public async Task<List<Weapon>> GetUserWeaponsFiltered(string userId)
    {
        var weapons = await GetUserWeapons(userId);
        // not sure if this is correct or the most efficient way to do this.
        var filter = weapons.Where(y => y.WeekDays.Split(',').Select(x => int.Parse(x))
        .Contains(dayOfWeek())).ToList();
        return filter;
    }
    private int dayOfWeek()
    {
        return ((int)DateTime.Now.DayOfWeek + 6) % 7;
    }
}
