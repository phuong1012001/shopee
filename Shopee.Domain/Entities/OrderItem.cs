using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Domain.Entities;

[Table("OrderItems")]
public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Order Order { get; set; }

    public virtual Product Product { get; set; }
}
