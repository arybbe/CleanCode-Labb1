using Moq;
using WebShop;
using WebShop.Notifications;

namespace WebShopTests;

public class NotificationContextTests
{
    private readonly Mock<INotificationStrategy> _mockEmailStrategy;
    private readonly Mock<INotificationStrategy> _mockSmsStrategy;
    private readonly NotificationContext _notificationContext;
    public NotificationContextTests()
    {
        _mockEmailStrategy = new Mock<INotificationStrategy>();
        _mockSmsStrategy = new Mock<INotificationStrategy>();
        var strategies = new List<INotificationStrategy>
        {
            _mockEmailStrategy.Object,
            _mockSmsStrategy.Object
        };
        _notificationContext = new NotificationContext(strategies);
    }
    [Fact]
    public void Notify_ShouldCallEmailNotification_WhenTypeIsEmail()
    {
        // Arrange
        var product = new Product { Name = "Test Product" };
        _mockEmailStrategy.Setup(s => s.Type).Returns(NotificationType.Email);
        // Act
        _notificationContext.Notify(product, NotificationType.Email);
        // Assert
        _mockEmailStrategy.Verify(s => s.Notify(product), Times.Once);
    }
    [Fact]
    public void Notify_ShouldCallSmsNotification_WhenTypeIsSms()
    {
        // Arrange
        var product = new Product { Name = "Test Product" };
        _mockSmsStrategy.Setup(s => s.Type).Returns(NotificationType.Sms);
        // Act
        _notificationContext.Notify(product, NotificationType.Sms);
        // Assert
        _mockSmsStrategy.Verify(s => s.Notify(product), Times.Once);
    }
    [Fact]
    public void Notify_ShouldThrowException_WhenNoMatchingStrategy()
    {
        // Arrange
        var product = new Product { Name = "Test Product" };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            _notificationContext.Notify(product, (NotificationType)999));
    }
}