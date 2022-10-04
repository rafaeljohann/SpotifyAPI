namespace Spotify.Infra.CrossCutting.Services.Auth.Request
{
    public class TokenRequest
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public string GrantType { get; init; }

        public TokenRequest(
            string username, 
            string password, 
            string grantType)
        {
            Username = username;
            Password = password;
            GrantType = grantType;
        }
    }
}