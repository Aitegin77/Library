using DAL.Context;
using DAL.Seed;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    internal static class IApplicationBuilderExtension
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
            scope.ServiceProvider.GetRequiredService<LibraryDbContext>().Database.Migrate();
            var services = app.ApplicationServices.GetService<IServiceProvider>();
            DatabaseMigrator.SeedDatabaseAsync(services!).GetAwaiter().GetResult();
        }
    }
}
