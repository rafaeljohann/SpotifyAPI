using CsvHelper.Configuration;
using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Mappers.Csv
{
    public class TrackFeaturesMapper : ClassMap<TrackFeatures>
    {
        public TrackFeaturesMapper()
        {
            Map(m => m.Id).Ignore();
            Map(m => m.Acousticness).Index(0).Name("acousticness");
            Map(m => m.Danceability).Index(1).Name("danceability");
            Map(m => m.Energy).Index(2).Name("energy");
            Map(m => m.Instrumentalness).Index(3).Name("instrumentalness");
            Map(m => m.Liveness).Index(4).Name("liveness");
            Map(m => m.Loudness).Index(5).Name("loudness");
            Map(m => m.Speechiness).Index(6).Name("speechiness");
            Map(m => m.Valence).Index(7).Name("valence");
            Map(m => m.Mode).Index(8).Name("mode");
            Map(m => m.Key).Index(9).Name("key");
            Map(m => m.Tempo).Index(10).Name("tempo");
            Map(m => m.DurationMs).Index(11).Name("duration_ms");
        }
    }
}