using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class BaseDatabaseConfig
{
    public static IServiceCollection AddDataBaseConfig(this IServiceCollection services)
    {
        services.AddDbContext<BaseDbContext>(opt =>
        {
            opt.UseInMemoryDatabase("BaseApiDb");
            opt.EnableSensitiveDataLogging(true);
        });

        return services;
    }
}
