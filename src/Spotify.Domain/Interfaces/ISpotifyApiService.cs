using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Interfaces
{
    public interface ISpotifyApiService
    { 
        Task<IEnumerable<Track>> ObterMusicasPlaylistPorId(string id);
        Task<Album> ObterDadosAlbumPorId(string id);
        Task<Artist> ObterDadosArtistaPorId(string id);
        Task<TrackFeatures> ObterTrackFeaturesPorId(string id);
        Task<Track> ObterMusicaPorId(string id);
    }
}