namespace Spotify.Infra.ExternalServices.Spotify.Responses
{
    public class TracksResponse
    {
        public ICollection<ItemResponse> Items { get; set; }
    }
}