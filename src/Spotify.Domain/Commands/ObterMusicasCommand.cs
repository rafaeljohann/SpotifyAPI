using MediatR;

namespace Spotify.Domain.Commands
{
    public class ObterMusicasCommand : IRequest<byte[]>
    {
        public IEnumerable<string> IdMusicasExistentes { get; init; }

        public ObterMusicasCommand(IEnumerable<string> idMusicasExistentes)
        {
            IdMusicasExistentes = idMusicasExistentes;
        }
    }
}