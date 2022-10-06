using Spotify.Domain.ValueObjects;
using Spotify.Infra.ExternalServices.Spotify.Responses;

namespace Spotify.Infra.ExternalServices.Spotify.Mappers
{
    public class TrackFeaturesMap
    {
        public static TrackFeatures Map(TrackFeaturesResponse trackFeatures)
        {
            if (trackFeatures is default(TrackFeaturesResponse))
                return default;

            return new TrackFeatures(
                trackFeatures.Id,
                trackFeatures.Duration_Ms,
                trackFeatures.Tempo,
                trackFeatures.Valence,
                trackFeatures.Liveness,
                trackFeatures.Instrumentalness,
                trackFeatures.Acousticness,
                trackFeatures.Speechiness,
                trackFeatures.Mode,
                trackFeatures.Loudness,
                trackFeatures.Key,
                trackFeatures.Energy,
                trackFeatures.Danceability);
        }  
    }
}