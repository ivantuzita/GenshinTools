using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace GenshinTools.BlazorUI.Pages.Authentication;

public partial class Login
{
    public UserVM Model { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public string Message { get; set; }
    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }

    public Login() {

    }

    protected async Task HandleLogin() {
        if (await AuthenticationService.AuthenticateAsync(Model.Username, Model.Password)) {
            NavigationManager.NavigateTo("/");
        }
        Message = "Username and password not recognized.";
    }

    protected override void OnInitialized() {
        Model = new UserVM();
    }
}