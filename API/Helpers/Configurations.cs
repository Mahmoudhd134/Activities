using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace API.Helpers;

public static class Configurations
{
    public static async Task UseUpdateDatabaseIfFound(this WebApplication app)
    {
        await using var context = GetDbContextInstance(app);
        await context.Database.MigrateAsync();
    }

    public static async Task UseAddDummyDataIfEmpty(this WebApplication app)
    {
        await using var context = GetDbContextInstance(app);
        await Seed.AddDummyData(context);
    }

    private static ApplicationDbContext GetDbContextInstance(WebApplication app)
    {
        try
        {
            return app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }
        catch (Exception e)
        {
            var logger = app.Services.CreateScope().ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError("Error when getting ApplicationDbContext Service >> {}", e.Message);
            return null;
        }
    }
}