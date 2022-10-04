using MediatR;
using Spotify.Domain.ValueObjects;

namespace Spotify.Domain.Commands
{
    public class ObterMusicasMaisPopularesCommand : IRequest<IEnumerable<Musica>>
    { }
}