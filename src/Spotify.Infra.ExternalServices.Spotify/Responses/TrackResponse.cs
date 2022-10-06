namespace Spotify.Infra.ExternalServices.Spotify.Responses
{
    public class TrackResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public bool Explicit { get; set; }
        public AlbumResponse Album { get; set; }
        public ICollection<ArtistResponse> Artists { get; set; }
        public TrackFeaturesResponse TrackFeatures { get; set; }
    }
}