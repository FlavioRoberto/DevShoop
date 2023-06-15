using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevShoop.ProductAPI;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set;}
}
