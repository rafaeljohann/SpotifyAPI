namespace Spotify.Domain.ValueObjects
{
    public class Musica
    {
        public Guid Id { get; init; }
        public string? TrackArtist { get; init; }
        public string? TrackName { get; init; }
        public int Popularity { get; init; }
        public bool Explicit { get; init; }
        public decimal DurationMs { get; init; }
        public decimal Tempo { get; init; }
        public decimal Valence { get; init; }
        public decimal Liveness { get; init; }
        public decimal Instrumentalness { get; init; }
        public decimal Acousticness { get; init; }
        public decimal Speechiness { get; init; }
        public int Mode { get; init; }
        public decimal Loudness { get; init; }
        public int Key { get; init; }
        public decimal Energy { get; init; }
        public decimal Danceability { get; init; }

        // gênero da música

        public Musica(
            Guid id, 
            string? trackArtist, 
            string? trackName, 
            int popularity, 
            bool @explicit, 
            decimal durationMs, 
            decimal tempo, 
            decimal valence, 
            decimal liveness, 
            decimal instrumentalness, 
            decimal acousticness, 
            decimal speechiness, 
            int mode, 
            decimal loudness, 
            int key, 
            decimal energy, 
            decimal danceability)
        {
            Id = id;
            TrackArtist = trackArtist;
            TrackName = trackName;
            Popularity = popularity;
            Explicit = @explicit;
            DurationMs = durationMs;
            Tempo = tempo;
            Valence = valence;
            Liveness = liveness;
            Instrumentalness = instrumentalness;
            Acousticness = acousticness;
            Speechiness = speechiness;
            Mode = mode;
            Loudness = loudness;
            Key = key;
            Energy = energy;
            Danceability = danceability;
        }
    }
}