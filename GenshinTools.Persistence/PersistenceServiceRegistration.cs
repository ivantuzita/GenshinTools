using GenshinTools.Domain.Interfaces;
using GenshinTools.Persistence.DatabaseContext;
using GenshinTools.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenshinTools.Persistence; 
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<GenshinDatabaseContext>(options => {
            options.UseMySql(configuration.GetConnectionString("GenshinConnectionString"), ServerVersion.AutoDetect(
                configuration.GetConnectionString("GenshinConnectionString")));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserCharacterRepository, UserCharacterRepository>();
        services.AddScoped<IUserWeaponRepository, UserWeaponRepository>();

        return services;
    }
}
