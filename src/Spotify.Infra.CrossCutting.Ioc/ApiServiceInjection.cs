using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Infra.CrossCutting.Services.Auth;
using Spotify.Infra.ExternalServices.Spotify;

namespace Spotify.Infra.CrossCutting.Ioc
{
    public static class ApiServiceInjection
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<AutenticacaoMessageHandler>();

            services.AddHttpClient<ITokenService, TokenService>(client => 
            {
                var uri = configuration.GetValue<string>("AutenticacaoSettings:Endpoint");
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = TimeSpan.FromMinutes(3);
            })
            .AddHttpMessageHandler<AutenticacaoMessageHandler>();
        }
    }
}