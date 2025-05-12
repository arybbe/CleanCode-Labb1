using WebShop.Notifications;
using WebShop.Repositories;
using WebShop.UnitOfWork;

namespace WebShop.Extensions;

public static class ProductEndpointsExtension 
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products");

        group.MapGet("/", GetAll);
        group.MapPost("/", Add);

        return app;
    }

    private static async Task<IResult> Add(IProductRepository repo, IUnitOfWork unitOfWork, Product product, NotificationContext notificationContext, HttpRequest req)
    {
        // Lägger till produkten via repository
        repo.Add(product);

        // Sparar förändringar

        // Notifierar observatörer om att en ny produkt har lagts till
        unitOfWork.NotifyProductAdded(product);

        var q = req.Query["notificationType"].ToString();
        Enum.TryParse<NotificationType>(q, true, out var type);
        notificationContext.Notify(product, type);
        return Results.Ok();
    }

    private static async Task<IResult> GetAll(IProductRepository repo)
    {
        // Behöver använda repository via Unit of Work för att hämta produkter
        var products = repo.GetAll();
        return Results.Ok(products);
    }
}