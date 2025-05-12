using WebShop.Repositories;
using WebShop;

namespace WebShopTests;

[TestClass]
public class ProductRepositoryTests
{
    [TestMethod]
    public void Add_Then_GetAll_ReturnsAddedProduct()
    {
        var repo = new ProductRepository();
        var p = new Product { Id = 1, Name = "X" };

        repo.Add(p);
        var all = repo.GetAll().ToList();

        Assert.AreEqual(1, all.Count);
        Assert.AreEqual("X", all[0].Name);
    }
}