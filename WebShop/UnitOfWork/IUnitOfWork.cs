using WebShop.Repositories;

namespace WebShop.UnitOfWork
{
    // Gränssnitt för Unit of Work
    public interface IUnitOfWork
    {
        // Repository för produkter
        IProductRepository Products { get; } // Egenskap för att hämta produktrepositoryt
        
        // Sparar förändringar (om du använder en databas)
        Task<int> SaveChangesAsync(); // Asynkron metod för att spara förändringar
        void NotifyProductAdded(Product product); // Notifierar observatörer om ny produkt
    }
}

