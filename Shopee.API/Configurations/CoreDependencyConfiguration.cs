using Shopee.Infrastructure.DataAccess;

namespace Shopee.API.Configurations;

public static class CoreDependencyConfiguration
{
    public static void AddCoreDependencies(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDatabases(configuration);
    }
}
