using GenshinTools.BlazorUI;
using GenshinTools.BlazorUI.Interfaces;
using GenshinTools.BlazorUI.Services;
using GenshinTools.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7125"));

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();
builder.Services.AddScoped<IUserCharacterService, UserCharacterService>();
builder.Services.AddScoped<IUserWeaponService, UserWeaponService>();

await builder.Build().RunAsync();
