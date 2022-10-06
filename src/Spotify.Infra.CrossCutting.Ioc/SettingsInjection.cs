using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Infra.CrossCutting.Services.Auth.Settings;
using Spotify.Infra.CrossCutting.Settings;

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

            services.AddSingleton<SpotifyApiSettings>(p => 
            {
                var settings = new SpotifyApiSettings();
                configuration.Bind(nameof(SpotifyApiSettings), settings);
                return settings;
            });

            services.AddSingleton<SpotifyTopPlaylistsSettings>(p => 
            {
                var settings = new SpotifyTopPlaylistsSettings();
                configuration.Bind(nameof(SpotifyTopPlaylistsSettings), settings);
                return settings;
            });
        }
    }
}