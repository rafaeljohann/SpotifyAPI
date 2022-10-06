namespace Spotify.Infra.ExternalServices.Spotify.Responses
{
    public class TrackFeaturesResponse
    {
        public string Id { get; init; }
        public decimal Duration_Ms { get; init; }
        public decimal Tempo { get; init; }
        public decimal Valence { get; init; }
        public decimal Liveness { get; init; }
        public decimal Instrumentalness { get; init; }
        public decimal Acousticness { get; init; }
        public decimal Speechiness { get; init; }
        public int Mode { get; init; }
        public decimal Loudness { get; init; }
        public int Key { get; init; }
        public decimal Energy { get; init; }
        public decimal Danceability { get; init; }
    }
}