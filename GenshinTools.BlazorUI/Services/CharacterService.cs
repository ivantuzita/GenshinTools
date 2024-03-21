using AutoMapper;
using Blazored.LocalStorage;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Services; 
public class CharacterService : BaseHttpService, ICharacterService {
    private readonly IMapper _mapper;
    public CharacterService(IClient client, IMapper mapper, ILocalStorageService _localStorage) : base(client, _localStorage) {
        _mapper = mapper;
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
        var character = await _client.CharactersAsync(id);
        return _mapper.Map<CharacterVM>(character);
    }

}

