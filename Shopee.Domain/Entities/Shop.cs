using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Domain.Entities;

[Table("Shops")]
public class Shop : BaseEntity
{
    public Guid OwnerId { get; set; }

    [MaxLength(200)]
    public string Name { get; set; }
 
    [MaxLength(500)]
    public string Description { get; set; }
}
