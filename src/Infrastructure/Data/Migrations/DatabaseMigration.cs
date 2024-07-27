using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Migrations;

public static class DatabaseMigration
{
    public static async Task MigrateDatabase(IServiceProvider serviceProvider)
    { var dbContext = serviceProvider.GetRequiredService<FinancesDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}