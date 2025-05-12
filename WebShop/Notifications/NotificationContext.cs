namespace WebShop.Notifications;

public class NotificationContext(IEnumerable<INotificationStrategy> strategies)
{
    private readonly IEnumerable<INotificationStrategy> _strategies = strategies;

    public void Notify(Product product, NotificationType type)
    {
        // Hitta rätt strategi baserat på typ
        var strategy = _strategies.FirstOrDefault(s => s.Type == type)
                       ?? throw new InvalidOperationException($"Ingen strategi för {type}");
        strategy.Notify(product);
    }
}