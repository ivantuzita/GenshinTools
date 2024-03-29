using GenshinTools.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GenshinTools.BlazorUI.Pages;

public partial class Home
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    public string userId { get; set; }

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

    public string getWeekDay() {
        //0 = seg, 1 = ter, dai em diante
        var day = ((int)DateTime.Now.DayOfWeek + 6) % 7;
        return WeekDays[day];
    }

    protected async override Task OnInitializedAsync() {
        await ((ApiAuthenticationStateProvider)AuthenticationStateProvider)
            .GetAuthenticationStateAsync();
    }
}