using Microsoft.Extensions.Caching.Memory;
using Spotify.Infra.CrossCutting.Extensions;
using Spotify.Infra.CrossCutting.Services.Auth.Request;
using Spotify.Infra.CrossCutting.Services.Auth.Settings;

namespace Spotify.Infra.CrossCutting.Services.Auth
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IMemoryCache _cache;
        private readonly ITokenService _tokenService;
        private readonly IAutenticacaoSettings _settings;
        private readonly IAutenticacaoService _autenticacaoService;
        private DateTimeOffset Expiracao => DateTimeOffset.Now.AddHours(1);
        private TimeSpan LiberarCacheSeNaoUtilizadoPor = TimeSpan.FromHours(1);
        private const int TEMPO_ENTRE_TENTATIVAS = 1;
        private const string TOKEN_AUTENTICACAO = "TOKEN_AUTENTICACAO/{0}";

        // private static readonly IAsyncPolicy<TokenResponse> PoliticaRetentativa
        //     = CriarPoliticaRetentativa();

        public TokenProvider(
            IMemoryCache memoryCache,
            ITokenService tokenService,
            IAutenticacaoSettings settings,
            IAutenticacaoService autenticacaoService)
        {
            _cache = memoryCache;
            _tokenService = tokenService;
            _settings = settings;
            _autenticacaoService = autenticacaoService;
        }

        public async Task<string> GetTokenAsync()
        {
            return await _cache.GetOrCreateValueAsync(
                TOKEN_AUTENTICACAO,
                () => CriarTokenAsync(),
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = Expiracao,
                    SlidingExpiration = LiberarCacheSeNaoUtilizadoPor
                });
        }

        private async Task<string> CriarTokenAsync()
        {
            var request = CriarRequest();
            var result = await _tokenService.GetTokenAsync(request);

            if (result is null)
                return default;

            return result.Access_Token;
        }

        private TokenRequest CriarRequest()
        {
            return _autenticacaoService.Obter();
        }

        // private static IAsyncPolicy<TokenResponse> CriarPoliticaRetentativa()
        // {

        // }
    }
}