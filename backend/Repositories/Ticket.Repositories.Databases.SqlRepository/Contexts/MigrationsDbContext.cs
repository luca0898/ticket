using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ticket.Repositories.Databases.SqlRepository.Contexts;

public class MigrationsDbContext : DbContext
{
    public MigrationsDbContext() : base(new DbContextOptions<ApplicationDbContext>())
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ConfigurationBuilder builder = new();

        var currentDirectory = Directory.GetCurrentDirectory();

        builder.AddJsonFile(Path.Combine(currentDirectory, $"appsettings.json"), false, true);

        IConfigurationRoot config = builder
            .AddEnvironmentVariables()
            .Build();

        optionsBuilder.UseNpgsql(config.GetConnectionString("PostgresConnectionString"));

        base.OnConfiguring(optionsBuilder);
    }
}
