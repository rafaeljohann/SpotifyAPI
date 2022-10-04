using Newtonsoft.Json;

namespace Spotify.Infra.CrossCutting.Notifications
{
    public class NotificationResponse
    {
        [JsonProperty(Order = 1)]
        public string Error { get; init; }
        [JsonProperty(Order = 2)]
        public IReadOnlyCollection<Notification> Notifications;

        public NotificationResponse(
            string messageError, 
            IReadOnlyCollection<Notification> notifications)
        {
            Error = messageError;
            Notifications = notifications;
        }
    }
}