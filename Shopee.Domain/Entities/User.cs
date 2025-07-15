using Microsoft.AspNetCore.Identity;
using Shopee.Domain.Enums;
using Shopee.Domain.IEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopee.Domain.Entities;

[Table("Users")]
public class User : IdentityUser<Guid>, IBaseEntity, IIsDeletedEntity
{
    public UserRole Role { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
