using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GenshinTools.BlazorUI.Pages.Weapons;
public partial class Index
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    public IUserWeaponService UserWeaponService { get; set; }
    public List<WeaponVM> Weapons { get; private set; } = new List<WeaponVM>();
    public List<WeaponVM> DoneWeapons { get; private set; } = new List<WeaponVM>();

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

    public string getWeekDay()
    {
        //0 = seg, 1 = ter, dai em diante
        var day = ((int)DateTime.Now.DayOfWeek + 6) % 7;
        return WeekDays[day];
    }

    protected void DoneWeapon(int id)
    {
        var doneWeapon = Weapons.Single(r => r.Id == id);
        DoneWeapons.Add(doneWeapon);
        Weapons.Remove(doneWeapon);
    }

    protected void CancelWeapon(int id)
    {
        var cancelWeapon = DoneWeapons.Single(r => r.Id == id);
        Weapons.Add(cancelWeapon);
        DoneWeapons.Remove(cancelWeapon);
    }

    protected async override Task OnInitializedAsync()
    {
        await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        var userId = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetId();
        Weapons = await UserWeaponService.GetUserWeapons(userId);
        if (!Weapons.Any())
        {
            Weapons = await UserWeaponService.GetUserWeaponsFiltered(userId);
        }
    }
}