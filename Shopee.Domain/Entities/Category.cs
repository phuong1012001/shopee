using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Domain.Entities;

[Table("Categories")]
public class Category : BaseEntity
{
    [MaxLength(200)]
    public string Name { get; set; }
}
