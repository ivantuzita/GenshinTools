﻿using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces;
public interface IUserCharacterService {
    Task AssociateCharacterToUser(int userId, int charId);
    Task DisassociateCharacterToUser(int userId, int charId);
    Task<List<Character>> GetUserCharacters(int userId);
    Task<List<Character>> GetUserCharactersFiltered(int userId);
}
