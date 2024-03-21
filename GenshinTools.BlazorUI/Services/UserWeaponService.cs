using AutoMapper;
using Blazored.LocalStorage;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services {
    public class UserWeaponService : BaseHttpService, IUserWeaponService {

        private readonly IMapper _mapper;

    public UserWeaponService(IClient client, IMapper mapper, ILocalStorageService _localStorage) : base(client, _localStorage) {
            _mapper = mapper;
    }

        public async Task AssociateWeaponToUser(string userId, int weaponId) {
            await AddBearerToken();
            await _client.Link2Async(userId, weaponId);
        }

        public async Task DisassociateWeaponToUser(string userId, int weaponId) {
            await AddBearerToken();
            await _client.Unlink2Async(userId, weaponId);
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
}
