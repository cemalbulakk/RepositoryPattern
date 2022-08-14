using Microsoft.EntityFrameworkCore;
using Product.Infrastructure;

namespace Product.API.Extensions;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        try
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
            dbContext.Database.Migrate();
            //ApplicationDbContextSeed.SeedSampleDataAsync(dbContext).Wait();
        }
        catch (Exception)
        {
            //  throw;
        }

        return host;
    }
}