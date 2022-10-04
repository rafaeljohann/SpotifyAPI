using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify.Infra.CrossCutting.Services.Auth;
using Spotify.Infra.CrossCutting.Services.Auth.Request;
using Spotify.Infra.CrossCutting.Services.Auth.Response;
using Spotify.Infra.CrossCutting.Services.Auth.Settings;

namespace Spotify.Infra.ExternalServices.Spotify
{
    public sealed class TokenService : ITokenService
    {
        private readonly HttpClient _client;
        private readonly IAutenticacaoSettings _settings;

        public Task<TokenResponse> GetTokenAsync(TokenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}