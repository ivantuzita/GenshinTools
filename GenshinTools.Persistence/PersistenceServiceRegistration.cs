using GenshinTools.Domain.Interfaces;
using GenshinTools.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenshinTools.Persistence; 
public static class PersistenceServiceRegistration {

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<GenshinDatabaseContext>(options => {
            options.UseMySql(configuration.GetConnectionString("DatabaseConnectionString"), ServerVersion.AutoDetect(
                configuration.GetConnectionString("DatabaseConnectionString")));
        });

        return services;
    }
}
