using DevShoop.ProductAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevShoop.ProductAPI.Data.Context;

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
