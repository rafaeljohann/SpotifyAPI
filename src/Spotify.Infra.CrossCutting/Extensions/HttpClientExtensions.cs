using Spotify.Infra.CrossCutting.Extensions.Factories;

namespace Spotify.Infra.CrossCutting.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync(
            this HttpClient client,
            string endPoint,
            object command = null)
        {
            return await client.PostAsync(
                endPoint, 
                HttpContentFactory.CreateJsonContent(command));
        }
    }
}