namespace WebShop.Notifications;

public interface INotificationStrategy
{
    NotificationType Type { get; }
    void Notify(Product product);
}