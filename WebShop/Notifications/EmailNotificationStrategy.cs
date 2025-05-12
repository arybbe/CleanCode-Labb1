namespace WebShop.Notifications;

public class EmailNotificationStrategy : INotificationStrategy
{
    public NotificationType Type => NotificationType.Email;
    public void Notify(Product product)
    {
        // Här skulle koden för att skicka ett e-postmeddelande gå
        Console.WriteLine($"E-post skickad: Ny produkt tillagd - {product.Name}");
    }
}