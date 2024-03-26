using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GenshinTools.BlazorUI.Pages.Characters;
public partial class Index
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    public IUserCharacterService UserCharacterService { get; set; }

    public List<CharacterVM> Characters { get; private set; } = new List<CharacterVM>();
    protected List<CharacterVM> DoneCharacters { get; private set; } = new List<CharacterVM>();

    IDictionary<int, string> WeekDays = new Dictionary<int, string>()
    {
        {0, "Monday"},
        {1, "Tuesday"},
        {2, "Wednesday"},
        {3, "Thursday"},
        {4, "Friday"},
        {5, "Saturday"},
        {6, "Sunday"}
    };

    protected string getWeekDay()
    {
        //0 = seg, 1 = ter, dai em diante
        var day = ((int)DateTime.Now.DayOfWeek + 6) % 7;
        return WeekDays[day];
    }

    protected void DoneCharacter(int id) {
        var doneChar = Characters.Single(r => r.Id == id);
        DoneCharacters.Add(doneChar);
        Characters.Remove(doneChar);
    }

    protected void CancelCharacter(int id)
    {
        var cancelChar = DoneCharacters.Single(r => r.Id == id);
        Characters.Add(cancelChar);
        DoneCharacters.Remove(cancelChar);
    }

    protected async override Task OnInitializedAsync()
    {
        await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        var userId = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetId();
        //i need to be able to populate Character list only if it's not populated yet
        //is this the best way to do this?
        if (Characters.Count == 0) {
            Characters = await UserCharacterService.GetUserCharactersFiltered(userId);
        }  
    }
}