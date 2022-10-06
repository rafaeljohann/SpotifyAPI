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

        public async Task<IEnumerable<Track>> ObterMusicasPlaylistPorId(string id)
        {
            var rota = string.Format(_settings.Rotas.ObterPlaylistPorId, id);
            var request = await _httpClient.GetAsync(rota);

            if (!request.IsSuccessStatusCode)
                return default;

            var response = await request.Content.ReadAsJsonAsync<PlaylistResponse>();
            return TrackMap.Map(response.Tracks.Items);
        }

        public async Task<Album> ObterDadosAlbumPorId(string id)
        {
            var rota = string.Format(_settings.Rotas.ObterAlbumPorId, id);
            var request = await _httpClient.GetAsync(rota);

            if (!request.IsSuccessStatusCode)
                return default;

            var response = await request.Content.ReadAsJsonAsync<AlbumResponse>();
            return AlbumMap.Map(response);
        }

        public async Task<Artist> ObterDadosArtistaPorId(string id)
        {
            var rota = string.Format(_settings.Rotas.ObterArtistaPorId, id);
            var request = await _httpClient.GetAsync(rota);

            if (!request.IsSuccessStatusCode)
                return default;

            var response = await request.Content.ReadAsJsonAsync<ArtistResponse>();
            return ArtistMap.Map(response);
        }

        public async Task<TrackFeatures> ObterTrackFeaturesPorId(string id)
        {
            var rota = string.Format(_settings.Rotas.ObterAnaliseMusicaPorId, id);
            var request = await _httpClient.GetAsync(rota);

            if (!request.IsSuccessStatusCode)
                return default;

            var response = await request.Content.ReadAsJsonAsync<TrackFeaturesResponse>();
            return TrackFeaturesMap.Map(response);
        }
    }
}