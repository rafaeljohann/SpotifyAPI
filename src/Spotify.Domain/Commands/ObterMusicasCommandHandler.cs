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
        private const int LIMITE_MAXIMO_BUSCA = 1000;

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
        }

        public async Task<byte[]> Handle(
            ObterMusicasCommand request, CancellationToken cancellationToken)
        {
            var relatorioCsv = default(byte[]);
            int quantidadeMusicasInseridas = 0;
            IList<PropertyInfo> properties = typeof(SpotifyTopPlaylistsSettings).GetProperties().ToList();
            var musicasExportacao = new List<Track>();

            foreach (PropertyInfo property in properties)
            {
                if (quantidadeMusicasInseridas >= LIMITE_MAXIMO_BUSCA)
                    break;

                var musicasPlaylist = await _spotifyApiService
                    .ObterMusicasPlaylistPorId(property
                        .GetValue(_spotifyTopPlaylistsSettings, null)
                        .ToString());
                
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

                    musicasExportacao.Add(musica);

                    quantidadeMusicasInseridas += 1;

                    if (quantidadeMusicasInseridas >= LIMITE_MAXIMO_BUSCA)
                        break;
                }
            }

            relatorioCsv = await _geradorCsvService.Gerar(musicasExportacao);
            return relatorioCsv;
        }
    }
}