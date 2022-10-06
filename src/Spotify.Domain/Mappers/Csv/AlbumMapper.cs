using CsvHelper.Configuration;
using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Mappers.Csv
{
    public class AlbumMapper : ClassMap<Album>
    {
        public AlbumMapper()
        {
            Map(m => m.Name).Index(0).Name("track_album");
            Map(m => m.ReleaseDate).Index(1).Name("release_date");
            Map(m => m.Id).Ignore();
            Map(m => m.Genres).Ignore();
        }
    }
}