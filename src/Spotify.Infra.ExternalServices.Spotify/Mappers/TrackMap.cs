using Spotify.Domain.ValueObjects;
using Spotify.Infra.ExternalServices.Spotify.Responses;

namespace Spotify.Infra.ExternalServices.Spotify.Mappers
{
    public static class TrackMap
    {
        public static Track Map(ItemResponse track)
        {
            if (track is default(ItemResponse) || track.Track is null)
                return default;

            return new Track(
                    track.Track.Id,
                    track.Track.Explicit,
                    track.Track.Name,
                    track.Track.Popularity,
                    AlbumMap.Map(track.Track.Album),
                    ArtistMap.Map(track.Track.Artists),
                    TrackFeaturesMap.Map(track.Track.TrackFeatures));
        }

        public static ICollection<Track> Map(ICollection<ItemResponse> track)
            => track?.Select(x => Map(x)).ToList() ?? new List<Track>();
    }
}