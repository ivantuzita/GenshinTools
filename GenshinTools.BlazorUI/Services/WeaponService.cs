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

        public async Task<Response<Guid>> CreateWeaponAsync(WeaponVM weapon) {
            try {
                await AddBearerToken();
                var newWeapon = _mapper.Map<WeaponDTO>(weapon);
                await _client.WeaponsPOSTAsync(newWeapon);
                return new Response<Guid> {
                    Success = true,
                };
            }
            catch (ApiException ex) {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteWeaponByIdAsync(int id) {
            try {
                await AddBearerToken();
                await _client.WeaponsDELETEAsync(id);
                return new Response<Guid> { Success = true, };
            }
            catch (ApiException ex) {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<WeaponVM>> GetAllWeaponsAsync() {
            await AddBearerToken();
            var weapons = await _client.WeaponsAllAsync();
            return _mapper.Map<List<WeaponVM>>(weapons);
        }

        public async Task<WeaponVM> GetWeaponByIdAsync(int id) {
            await AddBearerToken();
            var weapon = await _client.WeaponsGETAsync(id);
            return _mapper.Map<WeaponVM>(weapon);
        }

        public async Task<Response<Guid>> UpdateWeaponAsync(int id, WeaponVM weapon) {
            try {
                await AddBearerToken();
                var newWeapon = _mapper.Map<WeaponDTO>(weapon);
                await _client.WeaponsPUTAsync(id.ToString(), newWeapon);
                return new Response<Guid> {
                    Success = true,
                };
            }
            catch (ApiException ex) {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
