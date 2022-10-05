using Spotify.Domain.Interfaces;
using Spotify.Domain.ValueObjects;
using Spotify.Infra.CrossCutting.Extensions;
using Spotify.Infra.CrossCutting.Notifications;
using Spotify.Infra.CrossCutting.Settings;
using Spotify.Infra.ExternalServices.Spotify.Mappers;
using Spotify.Infra.ExternalServices.Spotify.Responses;

namespace Spotify.Infra.ExternalServices.Spotify.Services
{
    public class SpotifyApiService : ISpotifyApiService
    {
        private readonly HttpClient _httpClient;
        private readonly SpotifyApiSettings _settings;
        private readonly INotificationContext _notificationContext;

        public SpotifyApiService(
            HttpClient httpClient,
            SpotifyApiSettings settings,
            INotificationContext notificationContext)
        {
            _httpClient = httpClient;
            _settings = settings;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<Musica>> ObterMusicasPlaylistPorId(string id)
        {
            var rota = string.Format(_settings.Rotas.ObterPlaylistPorId, id);
            var request = await _httpClient.GetAsync(rota);

            if (!request.IsSuccessStatusCode)
                return default;

            var response = await request.Content.ReadAsJsonAsync<PlaylistResponse>();
            return MusicaMap.Map(response.Tracks.Items);
        }
    }
}