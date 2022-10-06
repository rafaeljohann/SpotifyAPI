using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Interfaces
{
    public interface IGeradorCsvService
    {
        Task<byte[]> Gerar(IEnumerable<Track> tracks);
    }
}