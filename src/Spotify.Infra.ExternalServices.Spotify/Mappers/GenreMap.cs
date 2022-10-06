using Spotify.Domain.ValueObjects;
using Spotify.Infra.ExternalServices.Spotify.Responses;

namespace Spotify.Infra.ExternalServices.Spotify.Mappers
{
    public class GenreMap
    {
        public static Genre Map(GenreResponse genre)
        {
            if (genre is default(GenreResponse))
                return default;

            return new Genre(
                genre.Name);
        }

        public static ICollection<Genre> Map(ICollection<GenreResponse> genres)
            => genres?.Select(x => Map(x)).ToList() ?? new List<Genre>();
    }
}