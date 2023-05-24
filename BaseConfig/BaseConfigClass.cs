using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class BaseConfigClass
{
    public static IServiceCollection AddBaseConfig(this IServiceCollection services)
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
        return services;
    }

    public static IApplicationBuilder UseBaseConfig(
        this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();

        return app;
    }
}