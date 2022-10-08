using System.Reflection;
using MediatR;
using Spotify.Domain.Interfaces;
using Spotify.Domain.ValueObjects;
using Spotify.Infra.CrossCutting.Notifications;
using Spotify.Infra.CrossCutting.Settings;

namespace Spotify.Domain.Commands
{
    public class ObterMusicasCommandHandler
        : IRequestHandler<ObterMusicasCommand, byte[]>
    {
        private readonly ISpotifyApiService _spotifyApiService;
        private readonly INotificationContext _notificationContext;
        private readonly IGeradorCsvService _geradorCsvService;
        private readonly SpotifyTopPlaylistsSettings _spotifyTopPlaylistsSettings;
        private List<Track> _musicasExportacao;

        public ObterMusicasCommandHandler(
            ISpotifyApiService spotifyApiService,
            INotificationContext notificationContext,
            IGeradorCsvService geradorCsvService,
            SpotifyTopPlaylistsSettings spotifyTopPlaylistsSettings)
        {
            _spotifyApiService = spotifyApiService;
            _notificationContext = notificationContext;
            _geradorCsvService = geradorCsvService;
            _spotifyTopPlaylistsSettings = spotifyTopPlaylistsSettings;
            _musicasExportacao = new List<Track>();
        }

        public async Task<byte[]> Handle(
            ObterMusicasCommand request, CancellationToken cancellationToken)
        {
            if (request.IdMusicasExistentes is not null)
                await InserirDadosMusicasExistentes(request.IdMusicasExistentes);

           await BuscarMusicasPorPlaylists();

            var relatorioCsv = await _geradorCsvService.Gerar(_musicasExportacao);
            return relatorioCsv;
        }

        private async Task BuscarMusicasPorPlaylists()
        {
            IList<PropertyInfo> properties = typeof(SpotifyTopPlaylistsSettings).GetProperties().ToList();

            foreach (PropertyInfo property in properties)
            {
                var musicasPlaylist = await _spotifyApiService
                    .ObterMusicasPlaylistPorId(property
                        .GetValue(_spotifyTopPlaylistsSettings, null)
                        .ToString());
                
                if (musicasPlaylist is null)
                    return;

                foreach (var musica in musicasPlaylist)
                {
                    await AtribuirDadosMusica(musica);
                    _musicasExportacao.Add(musica);
                }
            }
        }

        private async Task InserirDadosMusicasExistentes(
            IEnumerable<string> idMusicasExistentes)
        {
            foreach (var id in idMusicasExistentes)
            {
                var musica = await _spotifyApiService.ObterMusicaPorId(id);

                if (musica is null)
                    continue;

                await AtribuirDadosMusica(musica);
                _musicasExportacao.Add(musica);
            }
        }

        public async Task AtribuirDadosMusica(Track track)
        {
            if (track is null)
                return;

            var listaArtistas = new List<Artist>();

            var dadosAlbum = await _spotifyApiService.ObterDadosAlbumPorId(track?.Album?.Id);
            track.AtribuirAlbum(dadosAlbum);

            foreach (var artista in track.Artists)
            {
                var dadosArtista = await _spotifyApiService
                    .ObterDadosArtistaPorId(artista.Id);

                listaArtistas.Add(dadosArtista);
            }
            track.AtribuirArtistas(listaArtistas);

            var dadosMusica = await _spotifyApiService.ObterTrackFeaturesPorId(track.Id);
            track.AtribuirTrackFeatures(dadosMusica);
        } 
    }
}