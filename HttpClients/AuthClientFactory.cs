using Microsoft.Extensions.DependencyInjection;
using System.Net;

public static class AuthClientFactory
{
    public static IServiceCollection AddAuthClient(this IServiceCollection services)
    {
        services.AddHttpClient<AuthClient>()
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    CookieContainer = new CookieContainer(),
                    UseCookies = true
                });

        return services;
    }
}
