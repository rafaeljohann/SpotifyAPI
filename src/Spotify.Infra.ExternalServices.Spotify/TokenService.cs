using System.Text;
using Spotify.Infra.CrossCutting.Extensions;
using Spotify.Infra.CrossCutting.Notifications;
using Spotify.Infra.CrossCutting.Services.Auth;
using Spotify.Infra.CrossCutting.Services.Auth.Request;
using Spotify.Infra.CrossCutting.Services.Auth.Response;
using Spotify.Infra.CrossCutting.Services.Auth.Settings;

namespace Spotify.Infra.ExternalServices.Spotify
{
    public sealed class TokenService : ITokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IAutenticacaoSettings _settings;
        private readonly INotificationContext _notificationContext;

        public TokenService(
            HttpClient httpClient,
            IAutenticacaoSettings autenticacaoSettings,
            INotificationContext notificationContext)
        {
            _httpClient = httpClient;
            _settings = autenticacaoSettings;
            _notificationContext = notificationContext;
        }

        public static string Base64Encode(string textToEncode)
        {
            byte[] textAsBytes = Encoding.UTF8.GetBytes(textToEncode);
            return Convert.ToBase64String(textAsBytes);
        }

        public async Task<TokenResponse> GetTokenAsync(TokenRequest request)
        {
            var username = _settings.Username;
            var password = _settings.Password;
            _httpClient.DefaultRequestHeaders.Add($"Authorization", $"Basic {Base64Encode($"{username}:{password}")}");
            
            var result = await _httpClient.PostAsync(
                _settings.Endpoint,
                new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", request.GrantType)
                }));

            if (!result.IsSuccessStatusCode)
            {
                _notificationContext.AddNotification(
                    "TOKEN",
                    "Ocorreu um erro ao requisitar token de acesso");
            }

            result.EnsureSuccessStatusCode();
            
            return await result.Content.ReadAsJsonAsync<TokenResponse>();
        }
    }
}