using Blazored.LocalStorage;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Providers;
using GenshinTools.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace GenshinTools.BlazorUI.Services;
public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authStateProvider;
    public AuthenticationService(IClient client, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider) : base(client, localStorage)
    {
        _authStateProvider = authStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string username, string password)
    {
        try
        {
            AuthRequest authRequest = new AuthRequest
            {
                Username = username,
                Password = password
            };

            var authResponse = await _client.LoginAsync(authRequest);

            if (authResponse.Token != string.Empty)
            {
                await _localStorage.SetItemAsync("token", authResponse.Token);
                //overriding AuthenticationStateProvider with my ApiAuthenticationProvider
                await ((ApiAuthenticationStateProvider)_authStateProvider).LoggedIn();
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task Logout()
    {
        //overriding AuthenticationStateProvider with my ApiAuthenticationProvider
        await ((ApiAuthenticationStateProvider)_authStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(string username, string password)
    {
        await AddBearerToken();
        try
        {
            RegistrationRequest regRequest = new RegistrationRequest
            {
                Username = username,
                Password = password
            };

            var response = await _client.RegisterAsync(regRequest);

            if (!string.IsNullOrEmpty(response.UserId)) {
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
