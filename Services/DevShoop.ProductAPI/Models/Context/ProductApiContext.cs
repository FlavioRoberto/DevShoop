using Microsoft.EntityFrameworkCore;

namespace DevShoop.ProductAPI;

public class ProductApiContext : DbContext
{
    public ProductApiContext()
    {
    }

    public ProductApiContext(DbContextOptions<ProductApiContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
