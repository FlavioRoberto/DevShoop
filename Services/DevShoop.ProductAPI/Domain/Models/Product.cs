using System.ComponentModel.DataAnnotations.Schema;
using DevShoop.ProductAPI.Domain.Exceptions;
using DevShoop.ProductAPI.Domain.Models.Base;

namespace DevShoop.ProductAPI.Domain.Models;

[Table("product")]
public class Product : BaseEntity
{
    public string Name { get; set; }

    public decimal Price { get; private set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public string ImageUrl { get; set; }

    public void AddPrice(decimal price)
    {
        if (price < 1 || price > 10000)
            throw new DomainException("price must be beteween 1 and 10000");

        Price = price;
    }
}
