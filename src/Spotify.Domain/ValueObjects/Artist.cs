namespace Spotify.Domain.ValueObjects
{
    public class Artist
    {
        public string Id { get; set; }
        public string Nome { get; init; }
        public ICollection<string> Genres { get; init; }

        public Artist(
            string id,
            string nome, 
            ICollection<string> genres)
        {
            Id = id;
            Nome = nome;
            Genres = genres;
        }
    }
}