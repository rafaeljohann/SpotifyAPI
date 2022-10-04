using Spotify.Infra.CrossCutting.Services.Auth.Request;
using Spotify.Infra.CrossCutting.Services.Auth.Settings;

namespace Spotify.Infra.CrossCutting.Services.Auth
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IAutenticacaoSettings _settings;
        public AutenticacaoService(IAutenticacaoSettings autenticacaoSettings)
        {
            _settings = autenticacaoSettings;
        }

        public TokenRequest Obter()
        {
            return new TokenRequest(
                _settings.Username, 
                _settings.Password, 
                _settings.GrantType);
        }
    }
}