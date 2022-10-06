using CsvHelper.Configuration;
using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Mappers.Csv
{
    public class GenresMapper : ClassMap<Genre>
    {
        public GenresMapper()
        {
            Map(m => m.Name).Index(0).Name("Genres");
        }
    }
}