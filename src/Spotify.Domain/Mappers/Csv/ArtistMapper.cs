using CsvHelper.Configuration;
using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Mappers.Csv
{
    public class ArtistMapper : ClassMap<Artist>
    {
        public ArtistMapper()
        {
            Map(m => m.Id).Ignore();
            Map(m => m.Name).Index(0).Name("track_artists");
            Map(m => m.Genres).Ignore();
        }
    }
}