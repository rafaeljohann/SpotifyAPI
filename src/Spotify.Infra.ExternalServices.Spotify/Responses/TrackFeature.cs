namespace Spotify.Infra.ExternalServices.Spotify.Responses
{
    public class TrackFeature
    {
        public int DurationMs { get; set; }
        public int Tempo { get; set; }
        public decimal Valence { get; set; }
        public decimal Liveness { get; set; }
        public decimal Instrumentalness { get; set; }
        public decimal Acousticness { get; set; }
        public decimal Speechiness { get; set; }
        public int Mode { get; set; }
        public decimal Loudness { get; set; }
        public int Key { get; set; }
        public decimal Energy { get; set; }
        public decimal Danceability { get; set; }
    }
}