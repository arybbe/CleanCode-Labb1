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

    private static async Task<IResult> Add(IProductRepository repo, IUnitOfWork unitOfWork, Product product)
    {
        repo.Add(product);
        unitOfWork.NotifyProductAdded(product);
        return Results.Ok();
    }

    private static async Task<IResult> GetAll(IProductRepository repo)
    {
        var products = repo.GetAll();
        return Results.Ok(products);
    }
}