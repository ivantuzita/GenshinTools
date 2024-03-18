using AutoMapper;
using Blazored.LocalStorage;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services {
    public class CharacterService : BaseHttpService, ICharacterService {
        private readonly IMapper _mapper;
        public CharacterService(IClient client, IMapper mapper, ILocalStorageService _localStorage) : base(client, _localStorage) {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateCharacterAsync(CharacterVM chara)
        {
            try
            {
                await AddBearerToken();
                var charvm = _mapper.Map<CharacterDTO>(chara);
                await _client.CharactersPOSTAsync(charvm);
                return new Response<Guid> {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteCharacterByIdAsync(int id)
        {
            try
            {
                await AddBearerToken();
                await _client.CharactersDELETEAsync(id);
                return new Response<Guid> {  Success = true, };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<CharacterVM>> GetAllCharactersAsync()
        {
            await AddBearerToken();
            var characters = await _client.CharactersAllAsync();
            return _mapper.Map<List<CharacterVM>>(characters);
        }

        public async Task<CharacterVM> GetCharacterByIdAsync(int id)
        {
            await AddBearerToken();
            var character = await _client.CharactersGETAsync(id);
            return _mapper.Map<CharacterVM>(character);
        }

        public async Task<Response<Guid>> UpdateCharacterAsync(int id, CharacterVM chara)
        {
            try
            {
                await AddBearerToken();
                var charvm = _mapper.Map<CharacterDTO>(chara);
                await _client.CharactersPUTAsync(id.ToString(), charvm);
                return new Response<Guid>
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}

