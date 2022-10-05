namespace Spotify.Infra.CrossCutting.Settings
{
    public class SpotifyApiSettings
    {
        public string Endpoint { get; set; }
        public RotasSpotify Rotas { get; set; }
    }

    public class RotasSpotify
    {
        public string ObterPlaylistPorId { get; set; }
        public string ObterMusicaPorId { get; set; }
        public string ObterAnaliseMusicaPorId { get; set; }
        public string ObterArtistaPorId { get; set; }
        public string ObterAlbumPorId { get; set; }    
    }
}