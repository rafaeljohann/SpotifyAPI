using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Infra.CrossCutting.Services.Auth.Settings;

namespace Spotify.Infra.CrossCutting.Ioc
{
    public static class SettingsInjection
    {
        public static void AddSettings(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAutenticacaoSettings>(p => {
                var settings = new AutenticacaoSettings();
                configuration.Bind(nameof(AutenticacaoSettings), settings);
                return settings;
            });
        }
    }
}