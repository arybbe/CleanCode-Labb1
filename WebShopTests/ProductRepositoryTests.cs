using WebShop.Repositories;
using WebShop;

namespace WebShopTests;

public class ProductRepositoryTests
{
    [Fact]
    public void Add_Then_GetAll_ReturnsAddedProduct()
    {
        // Arrange
        var repo = new ProductRepository();
        var product = new Product { Id = 1, Name = "Test" };

        // Act
        repo.Add(product);
        var products = repo.GetAll().ToList();

        // Assert
        Assert.Single(products);
        Assert.Equal("Test", products[0].Name);
    }
}