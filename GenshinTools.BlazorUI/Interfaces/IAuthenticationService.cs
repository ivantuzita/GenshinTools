namespace GenshinTools.BlazorUI.Interfaces;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(string username, string password);
    Task<bool> RegisterAsync(string username, string password);
    Task Logout();
}
