using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class BaseAuthClass
{
    public static IServiceCollection AddBaseAuth(this IServiceCollection services)
    {
        services
            .AddCors()
            .AddAuthentication()
            .AddJwtBearer();
        return services;
    }

    public static IApplicationBuilder UseBaseAuth(
        this IApplicationBuilder app)
    {
        app.UseCors();
        app.UseAuthentication();

        return app;
    }
}