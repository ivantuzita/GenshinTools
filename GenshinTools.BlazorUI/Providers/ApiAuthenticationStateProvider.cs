using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GenshinTools.BlazorUI.Providers;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

    public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
        jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        //creating a empty identity
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        //checking if there's any token on localStorage
        var isTokenPresent = await _localStorage.ContainKeyAsync("token");
        if (!isTokenPresent)
        {
            //if there's no token, return new authState with empty identity
            return new AuthenticationState(user);
        }

        // getting token from localStorage
        var savedToken = await _localStorage.GetItemAsync<string>("token");
        //getting values from token using jwt
        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

        //checking expiration date of token. if expired, returns empty identity
        if (tokenContent.ValidTo < DateTime.Now) {
            await _localStorage.RemoveItemAsync("token");
            return new AuthenticationState(user);
        }

        //getting claims
        var claims = await GetClaims();
        //finally populating user
        user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
        //return user identity
        return new AuthenticationState(user);
    }

    public async Task LoggedIn() {
        //getting claims
        var claims = await GetClaims();
        //creating identity using retrieved claims
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
        var authState = Task.FromResult(new AuthenticationState(user));
        //notifying blazor that authstate has changed
        NotifyAuthenticationStateChanged(authState);
    }

    public async Task LoggedOut() {
        //removing token from local storage
        await _localStorage.RemoveItemAsync("token");
        //creating empty identity
        var nobody = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(nobody));
        //notifying blazor that authstate has changed
        NotifyAuthenticationStateChanged(authState);
    }

    //is this even secure?
    public async Task<string> GetId() {
        //getting token from local storage
        var savedToken = await _localStorage.GetItemAsync<string>("token");
        //reading token using handler
        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
        //returning the value of claim 'uid', which is the userId in the api calls
        return tokenContent.Claims.First(claim => claim.Type == "uid").Value;
    }

    private async Task<List<Claim>> GetClaims() {
        //getting token from local storage
        var savedToken = await _localStorage.GetItemAsync<string>("token");
        // decoding(?) values from token using jwt
        var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);
        // getting list of claims from token
        var claims = tokenContent.Claims.ToList();
        // changing(?) the subject claim
        claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
        return claims;
    }
}
