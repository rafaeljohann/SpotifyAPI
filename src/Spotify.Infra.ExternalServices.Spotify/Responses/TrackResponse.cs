namespace Spotify.Infra.ExternalServices.Spotify.Responses
{
    public class TrackResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public bool Explicit { get; set; }
    }
}