using MediatR;
using Spotify.Domain.Interfaces;
using Spotify.Domain.ValueObjects;
using Spotify.Infra.CrossCutting.Notifications;

namespace Spotify.Domain.Commands
{
    public class ObterMusicasCommandHandler
        : IRequestHandler<ObterMusicasCommand, byte[]>
    {
        private readonly ISpotifyApiService _spotifyApiService;
        private readonly INotificationContext _notificationContext;
        private readonly IGeradorCsvService _geradorCsvService;
        public ObterMusicasCommandHandler(
            ISpotifyApiService spotifyApiService,
            INotificationContext notificationContext,
            IGeradorCsvService geradorCsvService)
        {
            _spotifyApiService = spotifyApiService;
            _notificationContext = notificationContext;
            _geradorCsvService = geradorCsvService;
        }

        public async Task<byte[]> Handle(
            ObterMusicasCommand request, CancellationToken cancellationToken)
        {
            // Obter playlists de acordo com settings.
            var musicasPlaylist = await _spotifyApiService.ObterMusicasPlaylistPorId("37i9dQZF1DXe2bobNYDtW8");
            
            if (musicasPlaylist is null)
                return default;

            foreach (var musica in musicasPlaylist)
            {
                var listaArtistas = new List<Artist>();

                var dadosAlbum = await _spotifyApiService.ObterDadosAlbumPorId(musica.Album?.Id);
                musica.AtribuirAlbum(dadosAlbum);

                foreach (var artista in musica.Artists)
                {
                    var dadosArtista = await _spotifyApiService
                        .ObterDadosArtistaPorId(artista.Id);

                    listaArtistas.Add(dadosArtista);
                }
                musica.AtribuirArtistas(listaArtistas);

                var dadosMusica = await _spotifyApiService.ObterTrackFeaturesPorId(musica.Id);
                musica.AtribuirTrackFeatures(dadosMusica);
            }

            var relatorioCsv = await _geradorCsvService.Gerar(musicasPlaylist);

            return relatorioCsv;
        }
    }
}