using Spotify.Domain.ValueObjects;
using Spotify.Infra.ExternalServices.Spotify.Responses;

namespace Spotify.Infra.ExternalServices.Spotify.Mappers
{
    public static class ArtistMap
    {
        public static Artist Map(ArtistResponse artist)
        {
            if (artist is default(ArtistResponse))
                return default;

            return new Artist(
                artist.Id,
                artist.Name,
                artist.Genres);
        }

        public static ICollection<Artist> Map(ICollection<ArtistResponse> artists)
            => artists?.Select(x => Map(x)).ToList() ?? new List<Artist>();
    }
}