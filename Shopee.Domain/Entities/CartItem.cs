using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Domain.Entities;

[Table("CartItems")]
public class CartItem : BaseEntity
{
    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual User User { get; set; }

    public virtual Product Product { get; set; }
}
