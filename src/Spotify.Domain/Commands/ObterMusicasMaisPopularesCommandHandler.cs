using MediatR;
using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Commands
{
    public class ObterMusicasMaisPopularesCommandHandler
        : IRequestHandler<ObterMusicasMaisPopularesCommand, IEnumerable<Musica>>
    {
        public Task<IEnumerable<Musica>> Handle(
            ObterMusicasMaisPopularesCommand request, CancellationToken cancellationToken)
        {
            // Obter playlists de acordo com settings.
            // Obtém análise da música e os dados necessários.

            // retorna lista das músicas em CSV.

            throw new NotImplementedException();
        }
    }
}