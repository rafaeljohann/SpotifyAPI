namespace Spotify.Infra.ExternalServices.Spotify.Responses
{
    public class ArtistResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> Genres { get; set; }       
    }
}