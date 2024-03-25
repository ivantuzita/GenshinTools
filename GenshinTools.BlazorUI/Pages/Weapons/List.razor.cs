using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using GenshinTools.BlazorUI.Interfaces;

namespace GenshinTools.BlazorUI.Pages.Weapons;
public partial class List
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IUserWeaponService UserWeaponService { get; set; }
    [Inject]
    public IWeaponService WeaponService { get; set; }
    protected string userId { get; set; }

    public List<WeaponVM> UserWeapons { get; private set; }
    public List<WeaponVM> Weapons { get; private set; }

    public string Message { get; set; } = string.Empty;

    protected async Task AssociateWeapon(int weaponId)
    {
        var response = await UserWeaponService.AssociateWeaponToUser(userId, weaponId);
        if (response.Success)
        {
            NavigationManager.Refresh();
        }
        else
        {
            Message = response.Message;
        }
    }

    protected async Task DisassociateWeapon(int weaponId)
    {
        var response = await UserWeaponService.DisassociateWeaponToUser(userId, weaponId);
        if (response.Success)
        {
            NavigationManager.Refresh();
        }
        else
        {
            Message = response.Message;
        }
    }

    protected List<WeaponVM> WeaponsYouDontOwn(List<WeaponVM> userweapons, List<WeaponVM> weapons)
    {
        var result = weapons.Where(p => !userweapons.Any(p2 => p2.Id == p.Id)).ToList();
        return result;
    }

    protected override async Task OnInitializedAsync()
    {
        userId = await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetId();
        UserWeapons = await UserWeaponService.GetUserWeapons(userId);
        Weapons = WeaponsYouDontOwn(UserWeapons, await WeaponService.GetAllWeaponsAsync());
    }
}