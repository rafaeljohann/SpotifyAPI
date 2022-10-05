using MediatR;
using Spotify.Domain.Interfaces;
using Spotify.Infra.CrossCutting.Notifications;

namespace Spotify.Domain.Commands
{
    public class ObterMusicasCommandHandler
        : IRequestHandler<ObterMusicasCommand>
    {
        private readonly ISpotifyApiService _spotifyApiService;
        private readonly INotificationContext _notificationContext;
        public ObterMusicasCommandHandler(
            ISpotifyApiService spotifyApiService,
            INotificationContext notificationContext)
        {
            _spotifyApiService = spotifyApiService;
            _notificationContext = notificationContext;
        }

        public async Task<Unit> Handle(
            ObterMusicasCommand request, CancellationToken cancellationToken)
        {
            // Obter playlists de acordo com settings.
            var musicasPlaylist = await _spotifyApiService.ObterMusicasPlaylistPorId("37i9dQZF1DXe2bobNYDtW8");
            // Obtém análise da música e os dados necessários.

            // retorna lista das músicas em CSV.

            return Unit.Value;
        }
    }
}