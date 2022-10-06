using CsvHelper.Configuration;
using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Mappers.Csv
{
    public class TrackMapper : ClassMap<Track>
    {
        public TrackMapper()
        {
            Map(m => m.Id).Index(0).Name("track_id");
            Map(m => m.TrackName).Index(1).Name("track_name");
            Map(m => m.Popularity).Index(2).Name("popularity");
            Map(m => m.Explicit).Index(3).Name("explicit");
            Map(m => m.Album).Ignore();
            Map(m => m.Artists).Ignore();
            Map(m => m.TrackFeatures).Ignore();
        }
    }
}