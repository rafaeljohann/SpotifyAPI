namespace Spotify.Infra.CrossCutting.Services.Auth.Settings
{
    public interface IAutenticacaoSettings
    {
        string Username { get; }
        string Password { get; }
        string Endpoint { get; }
        string GrantType { get; }
        string Rota { get; }
    }

    public class AutenticacaoSettings : IAutenticacaoSettings
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public string Endpoint { get; init; }
        public string GrantType { get; init; }
        public string Rota { get; init; }
    }
}