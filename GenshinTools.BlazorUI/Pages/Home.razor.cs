using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GenshinTools.BlazorUI.Pages;

public partial class Home
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    public IUserCharacterService UserCharacterService { get; set; }

    public List<CharacterVM> Characters { get; private set; }

    public int getWeekDay() {
        //0 = seg, 1 = ter, dai em diante
        return ((int)DateTime.Now.DayOfWeek + 6) % 7;
    }

    protected async override Task OnInitializedAsync() {
        await ((ApiAuthenticationStateProvider)AuthenticationStateProvider)
            .GetAuthenticationStateAsync();
        var userId = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider)
            .GetId();
        Characters = await UserCharacterService.GetUserCharacters(userId);
    }
}