namespace Spotify.Domain.ValueObjects
{
    public class Track
    {
        public string Id { get; init; }
        public string? TrackName { get; init; }
        public int Popularity { get; init; }
        public bool Explicit { get; init; }
        public ICollection<Artist> Artists { get; private set; }
        public Album Album { get; private set; }
        public TrackFeatures TrackFeatures { get; private set; }

        public Track(
            string id,
            bool @explicit,
            string trackName,
            int popularity,
            Album album,
            ICollection<Artist> artists,
            TrackFeatures trackFeatures)
        {
            Id = id;
            Explicit = @explicit;
            TrackName = trackName;
            Popularity = popularity;
            Album = album;
            Artists = artists;
            TrackFeatures = trackFeatures;
        }

        public void AtribuirAlbum(Album album)
        {
            Album = album;
        }

        public void AtribuirArtistas(ICollection<Artist> artists)
        {
            Artists = artists;
        }

        public void AtribuirTrackFeatures(TrackFeatures trackFeatures)
        {
            TrackFeatures = trackFeatures;
        }
    }
}