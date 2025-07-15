using Shopee.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Domain.Entities;

[Table("Orders")]
public class Order : BaseEntity
{
    public Guid BuyerId { get; set; }

    public OrderStatus Status { get; set; }

    public virtual User User { get; set; }
}
