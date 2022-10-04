using Microsoft.AspNetCore.Http;

namespace Spotify.Infra.CrossCutting.Services.Auth
{
    public class AutenticacaoMessageHandler : DelegatingHandler
    {
        private ITokenProvider _tokenProvider;
        private IHttpContextAccessor _accessor;

        public AutenticacaoMessageHandler(
            ITokenProvider tokenProvider,
            IHttpContextAccessor accessor)
        {
            _tokenProvider = tokenProvider;
            _accessor = accessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (await ObterToken() is string token && token is not default(string))
                request.Headers.Add("Authorization", $"Bearer {token}");

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> ObterToken()
        {
            return await _tokenProvider.GetTokenAsync();
        }
    }
}