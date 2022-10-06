namespace Spotify.Domain.ValueObjects
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; init; }
        public ICollection<string> Genres { get; init; }

        public Artist(
            string id,
            string name, 
            ICollection<string> genres)
        {
            Id = id;
            Name = name;
            Genres = genres;
        }
    }
}