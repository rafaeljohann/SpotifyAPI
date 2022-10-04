using Spotify.Infra.CrossCutting.Services.Auth.Request;

namespace Spotify.Infra.CrossCutting.Services.Auth
{
    public interface IAutenticacaoService
    {
        TokenRequest Obter();
    }
}