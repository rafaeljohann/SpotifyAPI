using Spotify.Domain.ValueObjects;
using Spotify.Infra.ExternalServices.Spotify.Responses;

namespace Spotify.Infra.ExternalServices.Spotify.Mappers
{
    public class AlbumMap
    {
        public static Album Map(AlbumResponse album)
        {
            if (album is default(AlbumResponse))
                return default;

            return new Album(
                album.Id,
                album.Name,
                GenreMap.Map(album.Genres));
        } 
    }
}