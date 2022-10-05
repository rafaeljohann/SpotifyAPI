using System.Text;
using Newtonsoft.Json;

namespace Spotify.Infra.CrossCutting.Extensions.Factories
{
    public static class HttpContentFactory
    {
        public static StringContent CreateJsonContent(object command)
        {
            return new StringContent(
                content: command is null ? string.Empty 
                    : JsonConvert.SerializeObject(command),
                encoding: Encoding.UTF8,
                mediaType: "application/json");
        }
    }
}