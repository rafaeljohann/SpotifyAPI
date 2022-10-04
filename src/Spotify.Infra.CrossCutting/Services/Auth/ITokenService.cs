using Spotify.Infra.CrossCutting.Services.Auth.Request;
using Spotify.Infra.CrossCutting.Services.Auth.Response;

namespace Spotify.Infra.CrossCutting.Services.Auth
{
    public interface ITokenService
    {
        Task<TokenResponse> GetTokenAsync(TokenRequest request);
    }
}