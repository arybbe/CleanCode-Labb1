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

    public static IResult Add(IProductRepository repo, IUnitOfWork unitOfWork, Product product)
    {
        // Behöver använda repository via Unit of Work för att lägga till produkter
        if (product == null) return Results.BadRequest("Product cannot be null");

        repo.Add(product);
        unitOfWork.NotifyProductAdded(product); // Notifiera observatörer om ny produkt
        return Results.Created($"/api/products/{product.Id}", product);
    }

    public static IResult GetAll(IProductRepository repo)
    {
        // Behöver använda repository via Unit of Work för att hämta produkter
        var products = repo.GetAll();
        return Results.Ok(products);
    }
}