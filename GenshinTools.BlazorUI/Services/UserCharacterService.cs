using AutoMapper;
using Blazored.LocalStorage;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services; 
public class UserCharacterService : BaseHttpService, IUserCharacterService {

    private readonly IMapper _mapper;

    public UserCharacterService(IClient client,
        IMapper mapper,
        ILocalStorageService _localStorage) : base(client, _localStorage) {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> AssociateCharacterToUser(string userId, int charId) {
        try
        {
            await AddBearerToken();
            await _client.LinkAsync(userId, charId);
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

    public async Task<Response<Guid>> DisassociateCharacterToUser(string userId, int charId) {
        try
        {
            await AddBearerToken();
            await _client.UnlinkAsync(userId, charId);
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

    public async Task<List<CharacterVM>> GetUserCharacters(string userId) {
        await AddBearerToken();
        var userCharacters = await _client.CAsync(userId);
        return _mapper.Map<List<CharacterVM>>(userCharacters);
    }

    public async Task<List<CharacterVM>> GetUserCharactersFiltered(string userId) {
        await AddBearerToken();
        var userCharacters = await _client.FilterAsync(userId);
        return _mapper.Map<List<CharacterVM>>(userCharacters);
    }
}
