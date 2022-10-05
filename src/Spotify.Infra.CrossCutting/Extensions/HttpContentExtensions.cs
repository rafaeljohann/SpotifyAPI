using Newtonsoft.Json;

namespace Spotify.Infra.CrossCutting.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(
            this HttpContent httpContent,
            JsonSerializerSettings jsonSerializerSettings = null)
        {
            string json = await httpContent.ReadAsStringAsync();

            if (jsonSerializerSettings is null)
                return JsonConvert.DeserializeObject<T>(json);

            return JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
        }
    }
}