namespace WebShop.Notifications;

public class SmsNotificationStrategy : INotificationStrategy
{
    public NotificationType Type => NotificationType.Sms;
    public void Notify(Product product)
    {
        // Här skulle koden för att skicka ett SMS gå
        Console.WriteLine($"SMS skickat: Ny produkt tillagd - {product.Name}");
    }
}