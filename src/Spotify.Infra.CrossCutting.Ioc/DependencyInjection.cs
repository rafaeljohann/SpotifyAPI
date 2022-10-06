using Microsoft.Extensions.DependencyInjection;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Services;
using Spotify.Infra.CrossCutting.Notifications;
using Spotify.Infra.CrossCutting.Services.Auth;
using Spotify.Infra.ExternalServices.Spotify;

namespace Spotify.Infra.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGeradorCsvService, GeradorCsvService>();
            services.AddScoped<INotificationContext, NotificationContext>();
        }
    }
}