using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Domain.Entities;

[Table("Products")]
public class Product : BaseEntity
{
    public Guid ShopId { get; set; }

    public Guid CategoryId { get; set; }

    [MaxLength(200)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public Shop Shop { get; set; }

    public Category Category { get; set; }
}
