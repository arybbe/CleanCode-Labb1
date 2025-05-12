using Microsoft.EntityFrameworkCore;

namespace WebShop;

public class WebShopDbContext : DbContext
{
    DbSet<Product> Products { get; set; }
}