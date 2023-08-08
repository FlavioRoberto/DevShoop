using System.Reflection;
using DevShoop.ProductAPI.Domain.Models;
using DevShoop.ProductAPI.Mapping;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Product> Products { get; set; }
}
