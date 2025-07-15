using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopee.Domain.Constants;
using Shopee.Infrastructure.DataAccess.DbContexts;

namespace Shopee.Infrastructure.DataAccess;

public static class DataAccessInjection
{
    public static void AddDatabases(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ShopeeDbContext>(configuration, ConfigKeys.Databases.Connection);
    }

    public static void RunMigration(this WebApplication app)
    {
        var autoMigration = app.Configuration.GetSection(ConfigKeys.AutoMigration).Get<bool>();
        if (!autoMigration) return;

        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ShopeeDbContext>();
        context.Database.Migrate();
    }

    private static void AddDbContext<TContext>(this IServiceCollection collection, IConfiguration configuration, string databaseKey) where TContext : DbContext
    {
        var connectionString = configuration.GetSection(databaseKey).Value;
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString), $"{databaseKey} connection string is null");

        var versionMajor = configuration.GetSection(ConfigKeys.Databases.VersionMajor).Get<int>();
        var versionMinor = configuration.GetSection(ConfigKeys.Databases.VersionMinor).Get<int>();
        var maxRetryCount = configuration.GetSection(ConfigKeys.Databases.MaxRetryCount).Get<int>();
        var maxRetryDelay = TimeSpan.FromSeconds(configuration.GetSection(ConfigKeys.Databases.MaxRetryDelaySec).Get<int>());

        var serverVersion = new MariaDbServerVersion(new Version(10, 11, 6));
        //collection.AddDbContext<TContext>(options =>
        //    options.UseMySql(
        //        connectionString,
        //        serverVersion)
        //    );

        collection.AddDbContext<TContext>(options =>
            options.UseMySql(
                connectionString,
                serverVersion,
                builder => builder.MigrationsAssembly("Shopee.Infrastructure")
                   .EnableRetryOnFailure(
                        maxRetryCount: maxRetryCount,
                        maxRetryDelay: maxRetryDelay,
                        errorNumbersToAdd: null
                    ))
            );

        collection.AddHealthChecks();
    }
}
