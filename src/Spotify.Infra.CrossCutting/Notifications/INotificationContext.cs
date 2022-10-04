namespace Spotify.Infra.CrossCutting.Notifications
{
    public interface INotificationContext
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message);

        void AddNotification(Notification notification);

        void AddNotifications(IReadOnlyCollection<Notification> notifications);

        void AddNotifications(IList<Notification> notifications);

        void AddNotifications(ICollection<Notification> notifications);
    }
}