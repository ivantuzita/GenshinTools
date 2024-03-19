using AutoMapper;
using Blazored.LocalStorage;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services {
    public class UserCharacterService : BaseHttpService, IUserCharacterService {

        private readonly IMapper _mapper;

        public UserCharacterService(IClient client, IMapper mapper, ILocalStorageService _localStorage) : base(client, _localStorage) {
            _mapper = mapper;
        }

        public async Task AssociateCharacterToUser(string userId, int charId) {
            await AddBearerToken();
            await _client.LinkAsync(userId, charId);
        }

        public async Task DisassociateCharacterToUser(string userId, int charId) {
            await AddBearerToken();
            await _client.UnlinkAsync(userId, charId);
        }

        public async Task<List<CharacterVM>> GetUserCharacters(string userId) {
            await AddBearerToken();
            var userCharacters = await _client.UserCharactersAsync(userId);
            return _mapper.Map<List<CharacterVM>>(userCharacters);
        }

        public async Task<List<CharacterVM>> GetUserCharactersFiltered(string userId) {
            await AddBearerToken();
            var userCharacters = await _client.FilterAsync(userId);
            return _mapper.Map<List<CharacterVM>>(userCharacters);
        }
    }
}
