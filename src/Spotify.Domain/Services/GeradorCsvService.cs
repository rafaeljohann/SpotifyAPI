using System.Globalization;
using CsvHelper;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Mappers.Csv;
using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Services
{
    public class GeradorCsvService : IGeradorCsvService
    {
        public async Task<byte[]> Gerar(IEnumerable<Track> tracks)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<TrackMapper>();
                csv.Context.RegisterClassMap<GenresMapper>();
                csv.Context.RegisterClassMap<AlbumMapper>();
                csv.Context.RegisterClassMap<ArtistMapper>();
                csv.Context.RegisterClassMap<TrackFeaturesMapper>();

                csv.WriteHeader<Track>();
                csv.WriteHeader<Genre>();
                csv.WriteHeader<Album>();
                csv.WriteHeader<Artist>();
                csv.WriteHeader<TrackFeatures>();
                csv.NextRecord();

                foreach(var track in tracks)
                {
                    var artistsNames = string.Empty;
                    var genres = BuscarGenerosAlbum(track.Album?.Genres);

                    if (track.Artists is not null)
                    {
                        foreach(var artist in track.Artists)
                        {
                            artistsNames += artist?.Name + " | ";

                            if (genres is not null && genres.Equals(string.Empty))
                            {
                                if (artist?.Genres is not null) 
                                {
                                    foreach (var genre in artist?.Genres)
                                    {
                                        genres += genre + " | ";
                                    }
                                }
                            }
                        }
                    }

                    var trackData = new 
                    {
                       TrackId = track.Id,
                       TrackName = track.TrackName,
                       Popularity = track.Popularity,
                       Explicit = track.Explicit,
                       Genres = genres,
                       TrackAlbum = track.Album?.Name,
                       ReleaseDate = track.Album?.ReleaseDate,
                       TrackArtists =  artistsNames,
                       Acousticness = track.TrackFeatures?.Acousticness,
                       Danceability = track.TrackFeatures?.Danceability,
                       Energy = track.TrackFeatures?.Energy,
                       Instrumentalness = track.TrackFeatures?.Instrumentalness,
                       Liveness = track.TrackFeatures?.Liveness,
                       Loudness = track.TrackFeatures?.Loudness,
                       Speechiness = track.TrackFeatures?.Speechiness,
                       Valence = track.TrackFeatures?.Valence,
                       Mode = track.TrackFeatures?.Mode,
                       Key = track.TrackFeatures?.Key,
                       Tempo = track.TrackFeatures?.Tempo,
                       DurationMs = track.TrackFeatures?.DurationMs
                    };

                    csv.WriteRecord(trackData);
                    csv.NextRecord();
                }

                await writer.FlushAsync();

                if (stream is null)
                    return default;

                byte[] bytes = stream.ToArray();
                return bytes;
            }
        }

        private string BuscarGenerosAlbum(IEnumerable<Genre> genres)
        {
            var genresTrack = string.Empty;

            if (genres is null)
                return default;

            if (genres.Any())
            {
                foreach (var genre in genres)
                {
                    genresTrack += genre + " | ";
                }
            }

            return genresTrack;
        }
    }
}