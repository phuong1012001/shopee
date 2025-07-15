using Microsoft.EntityFrameworkCore;
using Shopee.Infrastructure.DataAccess.Configurations;

namespace Shopee.Infrastructure.DataAccess.DbContexts;

public class ShopeeDbContext : DbContext
{
    public ShopeeDbContext()
    {
    }

    public ShopeeDbContext(DbContextOptions<ShopeeDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CartItemConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new ShopConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
    }
}
