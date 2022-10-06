namespace Spotify.Domain.ValueObjects
{
    public class Album
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public ICollection<Genre> Genres { get; init; }

        public Album(
            string id, 
            string name,
            ICollection<Genre> genres)
        {
            Id = id;
            Genres = genres;
        }
    }
}