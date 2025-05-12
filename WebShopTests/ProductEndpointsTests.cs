using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using WebShop;
using WebShop.Extensions;
using WebShop.Repositories;
using WebShop.UnitOfWork;

namespace WebShopTests;

public class ProductEndpointsTests
{
    [Fact]
    public void GetAll_ReturnsOk_WithProducts()
    {
        // Arrange
        var repoMock = new Mock<IProductRepository>();
        repoMock.Setup(r => r.GetAll())
            .Returns(new List<Product>
                { new() { Id = 1, Name = "A" } });

        // Act
        var result = ProductEndpointsExtension.GetAll(repoMock.Object);

        // Assert
        var ok = Assert.IsType<Ok<IEnumerable<Product>>>(result);
        Assert.Single(ok.Value);
        repoMock.Verify(r => r.GetAll(), Times.Once);
    }

    [Fact]
    public void Add_AddsProductAndNotifies_ReturnsOk()
    {
        // Arrange
        var p = new Product { Id = 2, Name = "B" };
        var repoMock = new Mock<IProductRepository>();
        var uowMock = new Mock<IUnitOfWork>();

        // Act
        var result = ProductEndpointsExtension.Add(repoMock.Object, uowMock.Object, p);

        // Assert
        repoMock.Verify(r => r.Add(p), Times.Once);
        uowMock.Verify(u => u.NotifyProductAdded(p), Times.Once);

        var ok = Assert.IsType<Ok<Product>>(result);
        Assert.Equal("B", ok.Value.Name);
    }
}