using AutoMapper;
using Blazored.LocalStorage;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;
using System;

namespace GenshinTools.BlazorUI.Services; 
public class UserWeaponService : BaseHttpService, IUserWeaponService {

    private readonly IMapper _mapper;

public UserWeaponService(IClient client, IMapper mapper, ILocalStorageService _localStorage) : base(client, _localStorage) {
        _mapper = mapper;
}

    public async Task<Response<Guid>> AssociateWeaponToUser(string userId, int weaponId) {
        try
        {
            await AddBearerToken();
            await _client.Link2Async(userId, weaponId);
            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DisassociateWeaponToUser(string userId, int weaponId) {
        try
        {
            await AddBearerToken();
            await _client.Unlink2Async(userId, weaponId);
            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<WeaponVM>> GetUserWeapons(string userId) {
        await AddBearerToken();
        var userWeapons = await _client.WAsync(userId);
        return _mapper.Map<List<WeaponVM>>(userWeapons);
    }

    public async Task<List<WeaponVM>> GetUserWeaponsFiltered(string userId) {
        await AddBearerToken();
        var userWeapons = await _client.Filter2Async(userId);
        return _mapper.Map<List<WeaponVM>>(userWeapons);
    }
}
