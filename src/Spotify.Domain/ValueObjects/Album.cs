namespace Spotify.Domain.ValueObjects
{
    public class Album
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string ReleaseDate { get; set; }
        public ICollection<Genre> Genres { get; init; }

        public Album(
            string id, 
            string name,
            string releaseDate,
            ICollection<Genre> genres)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            Genres = genres;
        }
    }
}