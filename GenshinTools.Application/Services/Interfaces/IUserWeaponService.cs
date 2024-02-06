﻿using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces;

public interface IUserWeaponService {
    Task AssociateWeaponToUser(int userId, int charId);
    Task DisassociateWeaponToUser(int userId, int charId);
    Task<List<Weapon>> GetUserWeapons(int userId);
    Task<List<Weapon>> GetUserWeaponsFiltered(int userId);
}
