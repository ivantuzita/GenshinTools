using GenshinTools.Application.Services;
using GenshinTools.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GenshinTools.Application; 
public static class ApplicationServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddAutoMapper(cfg => {
            
        }, typeof(ApplicationServiceRegistration).Assembly);

        services.AddScoped<ICharacterService, CharacterService>();
        services.AddScoped<IUserCharacterService, UserCharacterService>();
        services.AddScoped<IUserWeaponService, UserWeaponService>();
        services.AddScoped<IWeaponService, WeaponService>();

        return services;
    }
}
