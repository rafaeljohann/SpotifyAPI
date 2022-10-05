using Spotify.Domain.ValueObjects;
using Spotify.Infra.ExternalServices.Spotify.Responses;

namespace Spotify.Infra.ExternalServices.Spotify.Mappers
{
    public static class MusicaMap
    {
        public static Musica Map(ItemResponse track)
        {
            if (track is default(ItemResponse) || track.Track is null)
                return default;

            return new Musica(
                    track.Track.Id,
                    track.Track.Explicit,
                    track.Track.Name,
                    track.Track.Popularity);
        }

        public static ICollection<Musica> Map(ICollection<ItemResponse> track)
            => track?.Select(x => Map(x)).ToList() ?? new List<Musica>();
    }
}