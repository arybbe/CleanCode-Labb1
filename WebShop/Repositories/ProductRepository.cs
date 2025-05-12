namespace WebShop.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];

    public IEnumerable<Product> GetAll()
    {
        // Returnerar alla produkter
        return _products;
    }

    public void Add(Product product)
    {
        // Lägger till en ny produkt
        if (product == null) throw new ArgumentNullException(nameof(product));
        _products.Add(product);
    }
}