namespace Spotify.Domain.ValueObjects
{
    public class Genre
    {
        public string Name { get; init; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}