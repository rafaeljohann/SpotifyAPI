using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Interfaces
{
    public interface ISpotifyApiService
    { 
        Task<IEnumerable<Musica>> ObterMusicasPlaylistPorId(string id);
    }
}