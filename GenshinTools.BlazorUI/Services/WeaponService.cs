using AutoMapper;
using Blazored.LocalStorage;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;
using System;

namespace GenshinTools.BlazorUI.Services {
    public class WeaponService : BaseHttpService, IWeaponService {

        private readonly IMapper _mapper;

        public WeaponService(IClient client, IMapper mapper, ILocalStorageService _localStorage) :
            base(client, _localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<WeaponVM>> GetAllWeaponsAsync() {
            await AddBearerToken();
            var weapons = await _client.WeaponsAllAsync();
            return _mapper.Map<List<WeaponVM>>(weapons);
        }

        public async Task<WeaponVM> GetWeaponByIdAsync(int id) {
            await AddBearerToken();
            var weapon = await _client.WeaponsAsync(id);
            return _mapper.Map<WeaponVM>(weapon);
        }

    }
}
