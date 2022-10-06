namespace Spotify.Infra.ExternalServices.Spotify.Responses
{
    public class AlbumResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Release_Date { get; set; }
        public ICollection<GenreResponse> Genres { get; set; }
    }
}