using DevShoop.ProductAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevShoop.ProductAPI.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        
        builder.HasIndex(p => p.Id);

        builder.HasKey(p => p.Id);

        builder.Property(t => t.Name)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(p => p.Price)
               .HasColumnName("price")
               .IsRequired();

        builder.Property(p => p.Description)
               .HasColumnName("description")
               .HasMaxLength(500);

        builder.Property(p => p.Category)
               .HasColumnName("category_name")
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.ImageUrl)
               .HasColumnName("image_url")
               .HasMaxLength(300);
    }
}
